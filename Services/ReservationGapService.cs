using System;
using System.Collections.Generic;
using System.Linq;
using LetsGoCamping.Models;
using LetsGoCamping.Repository;

namespace LetsGoCamping.Services
{
    
    public class ReservationGapService : IReservationGapService
    {
        private readonly CampingContext _campingContext;

        public ReservationGapService(CampingContext campingContext)
        {
            _campingContext = campingContext; //Could use this to persist data 
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



        private bool IsSearchDatesValid(Search search, Reservations reservation)
        {
            bool result = true;
            var searchEndDate = DateTime.Parse(search.EndDate);
            var reservationStartDate = DateTime.Parse(reservation.StartDate);

            if( (reservationStartDate.Subtract(searchEndDate)).Days > 1 || reservationStartDate.Subtract(searchEndDate).Days > 1)
            {
                result = false;

            }
            
            return result;

        }

    }


    public interface IReservationGapService 
    {
        List<string> GetAllPossibleCampsites(CampingReservationSearch campingReservationSearch);

    }

}
