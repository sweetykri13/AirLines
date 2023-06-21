using DALBookAirLinesTicket.Models;
using System.Security.Cryptography;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DALBookAirLinesTicket
{
    public class AirLinesRepository
    {
        private AirBookingDBContext context;

        public AirLinesRepository(AirBookingDBContext context)
        { 
            this.context=context;
        }
        public List<BookFlight> GetAllFlightList()
        {
            var bookList = (from book in context.BookFlights orderby book.BookingId select book).ToList();
            return bookList;
        }
        public bool AddFlightBook(string passengerName,int noOfTicket,string flightNo)
        {
            bool status=false;
            try
            {
                BookFlight bookFlight = new BookFlight();
                bookFlight.PassengerName = passengerName;
                bookFlight.NoOfTicket = noOfTicket;
                bookFlight.FlightNo = flightNo;
                context.BookFlights.Add(bookFlight);
                context.SaveChanges();
                status = true;
            } catch(Exception)
            {
              status = false;
            }
            return status;
        }

        public bool DeleteFlighBook(int bookingId)
        {
            bool status=false;
            try
            {
                var flight = context.BookFlights.FirstOrDefault(f => f.BookingId == bookingId);
                if (flight != null)
                {
                    context.BookFlights.Remove(flight);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}