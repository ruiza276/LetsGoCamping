using System.Collections.Generic;

namespace LetsGoCamping.Models
{
    public class CampingReservationSearch
    {
        public Search Search {get; set;}
        public List<Campsites> Campsites {get; set;}
        public List<Reservations> Reservations {get; set;}

    }
}