using EventBook.Models;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;



namespace EventBook.Controllers

{

    public class BookingsController : Controller

    {

        private readonly ApplicationDbContext _context;



        public BookingsController(ApplicationDbContext context)

        {

            _context = context;

        }



        public async Task<IActionResult> Index()

        {

            var Booking = await _context.Bookings.Include(b => b.Venue).Include(b => b.Event).ToListAsync();

            return View(Booking);

        }



        public IActionResult Create()

        {

            ViewBag.Venues = _context.Venues.ToList();

            ViewBag.Events = _context.Events.ToList();

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Booking booking)

        {

            if (ModelState.IsValid)

            {



                _context.Add(booking);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(booking);

        }



        public async Task<IActionResult> Details(int id)

        {

            var booking = await _context.Bookings.Include(b => b.Venue).Include(b => b.Event).FirstOrDefaultAsync(b => b.BookingId == id);



            if (booking == null)

            {

                return NotFound();

            }

            return View(booking);



        }



        private bool BookingExists(int id)

        {

            return _context.Bookings.Any(b => b.BookingId == id);

        }



        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)

            {

                return NotFound();

            }

            ViewBag.Venues = _context.Venues.ToList();

            ViewBag.Events = _context.Events.ToList();

            return View(booking);

        }





    }

}





