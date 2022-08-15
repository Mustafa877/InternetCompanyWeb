using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Data;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace speedlinkWifiweb.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {

        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        public AboutController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> index()
        {
            return View(await _context.abouts.ToListAsync());
        }

        // GET: abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.abouts
                .FirstOrDefaultAsync(m => m.id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
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

        public async Task<IActionResult> Create(About about)
        {
            if (ModelState.IsValid)
            {
                uploadphotoaHomebgrond(about);

                _context.Add(about);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Upload Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var about = await _context.abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, About about)
        {
            if (id != about.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    uploadphotoaHomebgrond(about);

                    _context.Update(about);
                    TempData["SuccessMessage"] = "Update Successfully";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mainExists(about.id))
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
            return View(about);
        }

        // GET: abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.abouts
                .FirstOrDefaultAsync(m => m.id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var about = await _context.abouts.FindAsync(id);
            _context.abouts.Remove(about);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }

        void uploadphotoaHomebgrond(About model)
        {
            if (model.file_mainImage != null)
            {
                string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/main/About");

                string unigueFileName = Guid.NewGuid() + ".jpg";
                string filepath = Path.Combine(uploadsfolder, unigueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.file_mainImage.CopyTo(filestream);

                }
                model.mainImage = unigueFileName;
            }
        }
        private bool mainExists(int id)
        {
            return _context.abouts.Any(e => e.id == id);
        }
    }
}

