using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingStorage
    {
        IQueryable<Booking> GetActiveBookingList(Booking booking);
    }
}