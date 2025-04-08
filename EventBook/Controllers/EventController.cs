using EventBook.Models;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;



namespace EventBook.Controllers

{

    public class EventsController : Controller

    {

        private readonly ApplicationDbContext _context;
        
        public EventsController(ApplicationDbContext context)

        {

            _context = context;

        }



        public async Task<IActionResult> Index()

        {

            return View(await _context.Events.ToListAsync());

        }



        public IActionResult Create()

        {

            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Event ev)

        {

            if (ModelState.IsValid)

            {

                _context.Add(ev);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(ev);

        }



        public async Task<IActionResult> Edit(int id)

        {

            var ev = await _context.Events.FindAsync(id);

            return ev == null ? NotFound() : View(ev);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Event ev)

        {

            if (id != ev.EventId) return NotFound();



            if (ModelState.IsValid)

            {

                _context.Update(ev);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(ev);

        }



        public async Task<IActionResult> Delete(int id)

        {

            var ev = await _context.Events.FindAsync(id);

            return ev == null ? NotFound() : View(ev);

        }



        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)

        {

            var ev = await _context.Events.FindAsync(id);

            _context.Events.Remove(ev);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }



}

