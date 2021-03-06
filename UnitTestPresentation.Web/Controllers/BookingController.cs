﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestPresentation.DAL;
using UnitTestPresentation.DAL.Entities;
using UnitTestPresentation.Services;
using UnitTestPresentation.Web.Models;

namespace UnitTestPresentation.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;
        private readonly IRepository _repository;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService, IRepository repository)
        {
            _logger = logger;
            _bookingService = bookingService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(BookingViewModel booking)
        {
            var bookingEvent = _repository.Find<BookingEvent>(x => x.Id == booking.BookingEventId);
            var user = _repository.Find<User>(x => x.Id == booking.UserId);
            if (bookingEvent == null || user == null)
            {
                return NotFound();
            }

            _bookingService.Book(user, bookingEvent);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings(int userId)
        {
            var user = _repository.Find<User>(x => x.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = _bookingService.GetUserBookings(userId);
            var result2 = result.Count();
            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
