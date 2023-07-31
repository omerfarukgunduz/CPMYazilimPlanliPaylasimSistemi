using Microsoft.AspNetCore.Mvc;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using ServiceStack;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Portal.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;

        readonly private ICelebrationDayReadRepository _celebrationDayReadRepository;
        readonly private ICelebrationDayWriteRepository _celebrationDayWriteRepository;

        public TestController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, ICelebrationDayReadRepository celebrationDayReadRepository, ICelebrationDayWriteRepository celebrationDayWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _celebrationDayReadRepository = celebrationDayReadRepository;
            _celebrationDayWriteRepository = celebrationDayWriteRepository;
        }

        public ICelebrationDayWriteRepository CelebrationDayWriteRepository => _celebrationDayWriteRepository;

        [HttpGet]
        public async Task GetAsync()
        {
            CelebrationDay day = await _celebrationDayReadRepository.GetByIdAsync("8A8BD751-E1A6-40E7-B96A-9364DF88E561");
            day.CreatedBy = "gır gır";
            _celebrationDayWriteRepository.SaveAsync();
        }
        
    }
}
