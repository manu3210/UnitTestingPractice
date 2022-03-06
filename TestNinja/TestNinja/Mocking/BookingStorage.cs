using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class BookingStorage : IBookingStorage
    {
        public IQueryable<Booking> GetActiveBookingList(Booking booking)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");

            return bookings;
        }
    }
}