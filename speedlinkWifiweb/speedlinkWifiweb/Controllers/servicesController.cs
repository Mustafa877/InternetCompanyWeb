using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace speedlinkWifiweb.Controllers
{
    [Authorize]
    public class servicesController : Controller
    {


        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly Dbcount _context;
        public servicesController(Dbcount context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> index()
        {
            return View(await _context.services.ToListAsync());
        }

        // GET: abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.services
                .FirstOrDefaultAsync(m => m.id == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // GET: abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create(services services)
        {
            if (ModelState.IsValid)
            {

                _context.Add(services);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Upload Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var services = await _context.services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, services services)
        {
            if (id != services.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    _context.Update(services);
                    TempData["SuccessMessage"] = "Update Successfully";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mainExists(services.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.services
                .FirstOrDefaultAsync(m => m.id == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services = await _context.services.FindAsync(id);
            _context.services.Remove(services);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }


        private bool mainExists(int id)
        {
            return _context.services.Any(e => e.id == id);
        }
    }
}



