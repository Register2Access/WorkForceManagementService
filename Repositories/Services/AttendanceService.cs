//using AutoMapper;
//using WorkForceManagementService.Data;
//using WorkForceManagementService.Repositories.Interfaces;

//namespace WorkForceManagementService.Repositories.Services
//{
//    public class AttendanceService : IAttendanceService
//    {
//        private readonly WFMSContext _context;
//        private readonly IMapper _mapper;
//        public AttendanceService(WFMSContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }
//        public async Task<string> PunchIn(int userId)
//        {
//            var today = DateTime.UtcNow.Date;

//            var alreadyPunched = await _context.A
//        }

//        Task<string> IAttendanceService.PunchOut(int userId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
