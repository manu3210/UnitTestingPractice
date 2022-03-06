using System.Collections.Generic;

namespace TestNinja.Mocking
{
    public interface IBookingManager
    {
        IEnumerable<Booking> GetActiveBookingList(Booking booking);
    }
}