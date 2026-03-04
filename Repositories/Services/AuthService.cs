using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkForceManagementService.Data;
using WorkForceManagementService.Entities;
using WorkForceManagementService.ModelDTOs;
using WorkForceManagementService.Repositories.Interfaces;

namespace WorkForceManagementService.Repositories.Services
{
    public class AuthService : IAuthService
    {
        private readonly WFMSContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthService(WFMSContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<int> Register(RegisterDto registerDto)
        {
            if (registerDto == null) throw new ArgumentNullException(nameof(registerDto));

            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                throw new InvalidOperationException("Email already exists");

            if (!Enum.TryParse<UserRole>(registerDto.Role, true, out var userRole))
            {
                throw new ArgumentException($"Invalid role: {registerDto.Role}. Valid roles are: {string.Join(", ", Enum.GetNames<UserRole>())}");
            }

            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.PasswordHash);
            user.Role = userRole;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<String> Login(string email, string password)
        {
            var user = await _context.Users
            .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
                throw new Exception("User not exist");

            var verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!verified)
                throw new Exception("Invalid credentials");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            DateTime tokenExpiration;

            var expHours = _configuration.GetValue<int>("TokenSettings:TokenExpirationInHours");
            tokenExpiration = DateTime.UtcNow.AddHours(expHours);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSettings:SecretKey"]!));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiration,
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
