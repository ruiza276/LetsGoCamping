using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LetsGoCamping.Models;
using LetsGoCamping.Services;

namespace LetsGoCamping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampingReservationController : ControllerBase
    {
        private readonly ILogger<CampingReservationController> _logger; //One day...
        private readonly IReservationGapService _reservationGapService;
        public CampingReservationController(ILogger<CampingReservationController> logger, IReservationGapService reservationGapService)
        {
            _logger = logger;
            _reservationGapService = reservationGapService;
        }
        

        [HttpGet]
        public async Task<ActionResult<string>> GetPossibleCampsites(CampingReservationSearch campingReservationSearch) //Get campsites avaliable to book 
        {
            
            return Ok(_reservationGapService.GetAllPossibleCampsites(campingReservationSearch));
        }

    }
}