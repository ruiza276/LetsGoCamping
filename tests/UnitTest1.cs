using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using LetsGoCamping.Services;
using LetsGoCamping.Controllers;
using LetsGoCamping.Models;
using Microsoft.AspNetCore.Mvc;
using LetsGoCamping.Repository;

namespace tests
{
    public class Tests //These unit tests are dedicated to Nate, Wendy and Scott :D
    {

        [Test]
        public void HappyPath() //
        {
            ReservationGapService rgsMock = new ReservationGapService();
            CampingReservationController controller = new CampingReservationController(rgsMock);
            var campSeach = new CampingReservationSearch();
            campSeach.Search = new Search 
            {
                StartDate = "2018-06-04",
                EndDate = "2018-06-06"

            };
            campSeach.Campsites = new System.Collections.Generic.List<Campsites>();
            campSeach.Campsites.Add(new Campsites {Id = 1, Name = "Cozy Cabin"});
            campSeach.Campsites.Add(new Campsites {Id = 2, Name = "Comfy Cabin"});
            campSeach.Campsites.Add(new Campsites {Id = 3, Name = "Rustic Cabin"});
            campSeach.Campsites.Add(new Campsites {Id = 4, Name = "Rickety Cabin"});
            campSeach.Campsites.Add(new Campsites {Id = 5, Name = "Cabin in the Woods"});

            campSeach.Reservations = new System.Collections.Generic.List<Reservations>();
            campSeach.Reservations.Add(new Reservations {CampsiteId = 1, StartDate = "2018-06-01", EndDate="2018-06-03"});
            campSeach.Reservations.Add(new Reservations {CampsiteId = 1, StartDate = "2018-06-08", EndDate="2018-06-10"});

            campSeach.Reservations.Add(new Reservations {CampsiteId = 2, StartDate = "2018-06-01", EndDate="2018-06-01"});
            campSeach.Reservations.Add(new Reservations {CampsiteId = 2, StartDate = "2018-06-02", EndDate="2018-06-03"});
            campSeach.Reservations.Add(new Reservations {CampsiteId = 2, StartDate = "2018-06-07", EndDate="2018-06-09"});

            campSeach.Reservations.Add(new Reservations {CampsiteId = 3, StartDate = "2018-06-01", EndDate="2018-06-02"});
            campSeach.Reservations.Add(new Reservations {CampsiteId = 3, StartDate = "2018-06-08", EndDate="2018-06-09"});

            campSeach.Reservations.Add(new Reservations {CampsiteId = 4, StartDate = "2018-06-07", EndDate="2018-06-10"});
            List<string> happyResult = new List<string>(){"Comfy Cabin","Rickety Cabin","Cabin in the Woods"};

            var actionResult =  controller.GetPossibleCampsites(campSeach);
            var okObjectResult = (OkObjectResult)actionResult.Result;

            Assert.NotNull(okObjectResult.Value);
            Assert.AreEqual(happyResult, okObjectResult.Value);
        }

        [TestCase ("2018-06-08","2018-06-10")]
        [TestCase ("2018-05-12","2018-05-21")]
        [TestCase ("2018-06-01","2018-06-02")]
        public void IsSearchDatesValidReturnsFalseForInvalidDates(string startDate, string endDate)
        {

            Mock<CampingContext> conext = new Mock<CampingContext>();
            ReservationGapService gapService = new ReservationGapService();

            var search = new Search 
            {
                StartDate = "2018-06-04",
                EndDate = "2018-06-06"

            };

            var reservations = new Reservations {CampsiteId = 1, StartDate = startDate, EndDate = endDate};

            var result = gapService.IsSearchDatesValid(search, reservations);

            Assert.IsFalse(result);
        }
        
        [TestCase ("2018-06-02","2018-06-03")]
        [TestCase ("2018-06-07","2018-06-09")]
        [TestCase ("2018-06-07","2018-06-10")]
        [TestCase ("2018-06-03","2018-06-03")]
        [TestCase ("2018-06-07","2018-06-07")]
        [TestCase ("2018-06-01","2018-06-01")]
        [TestCase ("2018-06-08","2018-06-08")]
        public void IsSearchDatesValidReturnsTrueForValidDates(string startDate, string endDate)
        {

            Mock<CampingContext> conext = new Mock<CampingContext>();
            ReservationGapService gapService = new ReservationGapService();

            var search = new Search 
            {
                StartDate = "2018-06-04",
                EndDate = "2018-06-06"

            };

            var reservations = new Reservations {CampsiteId = 1, StartDate = startDate, EndDate = endDate};

            var result = gapService.IsSearchDatesValid(search, reservations);

            Assert.IsTrue(result);
        }
    }
}