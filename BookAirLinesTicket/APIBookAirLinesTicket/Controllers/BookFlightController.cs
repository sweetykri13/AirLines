using DALBookAirLinesTicket;
using DALBookAirLinesTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBookAirLinesTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFlightController : Controller
    {
        AirLinesRepository rep;
        public BookFlightController(AirLinesRepository repository)
        {
            rep = repository;
        }
        [HttpGet]
        public JsonResult GetAllBookDetails()
        {
            List<BookFlight> bookFlights=new List<BookFlight>();
            try
            {
                bookFlights = rep.GetAllFlightList();
            }
            catch (Exception)
            {

                bookFlights = null;
            }
            return Json(bookFlights);
        }
        [HttpPost]
        public JsonResult AddFlightBooking(string passengerName, int noOfTicket, string flightNo)
        {
            bool status=false;
            string message;
            try
            {
                status = rep.AddFlightBook(passengerName, noOfTicket, flightNo);
                  if (status)
                {
                    message = "Successful addition operation";
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }
        
    [HttpDelete]
    public bool DeleteFlightBooking(int bookingId)
    {
        bool status = false;
        string message;
            try
            {
                status = rep.DeleteFlighBook(bookingId);
            }
            catch (Exception)
            {

                status = false;
            }
            return status;

        }
    }
}

