using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingStorage> _bookingStorage;
        private IQueryable<Booking> _bookingList;

        [SetUp]
        public void SetUp()
        {
            _bookingStorage = new Mock<IBookingStorage>();

            var booking = new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2022, 03, 04),
                DepartureDate = new DateTime(2022, 03, 07),
                Reference = "booking2"
            };

            _bookingList = new List<Booking> { booking }.AsQueryable();

        }

        [Test]
        public void OverlappingBookingsExist_BookingStatusIsCancelled_ResturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Status = "Cancelled" }, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_NotOverLappingBookingItHappensBeforeAnotherOne_ReturnsAnEmptyString()
        {
            var booking = new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2022, 03, 06),
                DepartureDate = new DateTime(2022, 03, 03),
                Reference = "booking1",
                Status = "Active"
            };

            _bookingStorage.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_NotOverLappingBookingItHappensAfterAnotherOne_ReturnsAnEmptyString()
        {
            var booking = new Booking 
            { 
                Id = 1, 
                ArrivalDate = new DateTime(2022, 03, 13), 
                DepartureDate = new DateTime(2022, 03, 15)
            };

            _bookingStorage.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItFinishesInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking 
            {
                Id = 1, 
                ArrivalDate = new DateTime(2022, 03, 03), 
                DepartureDate = new DateTime(2022, 03, 05)
            };

            _bookingStorage.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItStartsInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking 
            {
                Id = 1, 
                ArrivalDate = new DateTime(2022, 03, 05), 
                DepartureDate = new DateTime(2022, 03, 09)
            };

            _bookingStorage.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItIsInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking
            { 
                Id = 1, 
                ArrivalDate = new DateTime(2022, 03, 05), 
                DepartureDate = new DateTime(2022, 03, 06)
            };

            _bookingStorage.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingStorage.Object);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }
    }
}
