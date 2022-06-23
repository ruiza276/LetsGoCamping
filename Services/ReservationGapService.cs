using System;
using System.Collections.Generic;
using System.Linq;
using LetsGoCamping.Models;
using LetsGoCamping.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LetsGoCamping.Services
{
    
    public class ReservationGapService : IReservationGapService
    {
        //private readonly CampingContext _campingContext;

        public ReservationGapService()
        {
            
        }

        public List<string> GetAllPossibleCampsites(CampingReservationSearch campingReservationSearch)
        {
            List<Campsites> results = campingReservationSearch.Campsites;
            

            foreach (var reservation in campingReservationSearch.Reservations)
            {
                var campsiteId = reservation.CampsiteId;
                if (IsSearchDatesValid(campingReservationSearch.Search, reservation) )
                {
                    continue;

                }
                else 
                {
                    results.RemoveAll(result => result.Id == campsiteId);
                }
                
            }

            List<string> names = results.Select(r => r.Name).ToList();
            return names;
        }



        public bool IsSearchDatesValid(Search search, Reservations reservation) //public so can test
        {
            bool result = true;
            var searchEndDate = DateTime.Parse(search.EndDate);
            var searchStartDate = DateTime.Parse(search.StartDate);

            var reservationStartDate = DateTime.Parse(reservation.StartDate);
            var reservationEndDate = DateTime.Parse(reservation.EndDate);

            if(reservationEndDate < searchStartDate.AddDays(-1) || reservationStartDate > searchEndDate.AddDays(1) )
            {
                result = false;
                if( reservationEndDate.Subtract(reservationStartDate).Days == 0  ) result = true; //not super happy with this TODO refactor pls 
            }

            return result;

        }

    }


    public interface IReservationGapService 
    {
        List<string> GetAllPossibleCampsites(CampingReservationSearch campingReservationSearch);

    }

}
