using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System.Linq;
using System.Threading.Tasks;

namespace speedlinkWifiweb.Controllers
{

    public class ContactUsController : Controller
    {
        private readonly Dbcount _context;

        public ContactUsController(Dbcount context)
        {
            _context = context;
        }

        // GET: ContactUs
        public IActionResult Index()
        {
            var result = _context.ContactUs.OrderByDescending(x => x.Id).ToList();
            return View(result);
        }

        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,email,subject,message")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {

                _context.Add(contactUs);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "The Message Send Successfully";

                return RedirectToAction("index", "home");
            }
            return View(contactUs);
        }

        // GET: ContactUs/Edit/5


        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.ContactUs.FindAsync(id);

            _context.ContactUs.Remove(contactUs);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "have been successfully deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
            return _context.ContactUs.Any(e => e.Id == id);
        }
    }
}
