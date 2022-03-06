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
        private BookingHelper _bookingHelper;
        private Mock<IBookingManager> _bookingManager;
        private List<Booking> _bookingList;

        [SetUp]
        public void SetUp()
        {
            _bookingManager = new Mock<IBookingManager>();
            _bookingHelper = new BookingHelper(_bookingManager.Object);
            _bookingList = new List<Booking> { new Booking { Id = 2, 
                                                             ArrivalDate = new DateTime(2022, 03, 04), 
                                                             DepartureDate = new DateTime(2022, 03, 07), 
                                                             Reference = "booking2",
                                                             Status = "Active"} };
        }

        [Test]
        public void OverlappingBookingsExist_BookingStatusIsCancelled_ResturnsEmptyString()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking { Status = "Cancelled" });

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

            _bookingManager.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_NotOverLappingBookingItHappensAfterAnotherOne_ReturnsAnEmptyString()
        {
            var booking = new Booking { Id = 1, 
                                        ArrivalDate = new DateTime(2022, 03, 13), 
                                        DepartureDate = new DateTime(2022, 03, 15), 
                                        Reference = "booking1", 
                                        Status = "Active" };

            _bookingManager.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItFinishesInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking { Id = 1, 
                                        ArrivalDate = new DateTime(2022, 03, 03), 
                                        DepartureDate = new DateTime(2022, 03, 05), 
                                        Reference = "booking1", 
                                        Status = "Active" };

            _bookingManager.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItStartsInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking { Id = 1, 
                                        ArrivalDate = new DateTime(2022, 03, 05), 
                                        DepartureDate = new DateTime(2022, 03, 09), 
                                        Reference = "booking1", 
                                        Status = "Active" };

            _bookingManager.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }

        [Test]
        public void OverlappingBookingsExist_OverLappingBookingItIsInTheMiddleOfAnotherOne_ReturnsReferenceOfExistingBooking()
        {
            var booking = new Booking { Id = 1, 
                                        ArrivalDate = new DateTime(2022, 03, 05), 
                                        DepartureDate = new DateTime(2022, 03, 06), 
                                        Reference = "booking1", 
                                        Status = "Active" };

            _bookingManager.Setup(bm => bm.GetActiveBookingList(booking)).Returns(_bookingList);

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo("Booking2").IgnoreCase);
        }
    }
}
