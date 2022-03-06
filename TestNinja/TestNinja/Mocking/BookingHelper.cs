using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class BookingHelper
    {
        private readonly IBookingManager _bookingManager;

        public BookingHelper(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        public string OverlappingBookingsExist(Booking booking)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = _bookingManager.GetActiveBookingList(booking);

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate < b.DepartureDate
                        && booking.DepartureDate > b.ArrivalDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}