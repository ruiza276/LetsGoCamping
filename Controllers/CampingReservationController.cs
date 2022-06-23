using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsGoCamping.Models;
using LetsGoCamping.Services;
using System.Collections.Generic;

namespace LetsGoCamping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampingReservationController : ControllerBase
    {
        private readonly IReservationGapService _reservationGapService;
        public CampingReservationController(IReservationGapService reservationGapService)
        {
            _reservationGapService = reservationGapService;
        }
        

        [HttpGet]
        public ActionResult<string> GetPossibleCampsites(CampingReservationSearch campingReservationSearch) //Get campsites avaliable to book 
        {
            return  Ok(_reservationGapService.GetAllPossibleCampsites(campingReservationSearch));
        }

    }
}