#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewJournalExample.Data;
using NewJournalExample.Models;

namespace NewJournalExample.Controllers
{
    public class JournalsController : Controller
    {
        private readonly NewJournalExampleContext _context;

        public JournalsController(NewJournalExampleContext context)
        {
            _context = context;
        }

        // GET: Journals
        public async Task<IActionResult> Index()
        {
            var newJournalExampleContext = _context.Journal.Include(j => j.Editor).Include(j => j.User);
            return View(await newJournalExampleContext.ToListAsync());
        }

        // GET: Journals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .Include(j => j.Editor)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JournalNumber == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // GET: Journals/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber");
            ViewData["UserNumber"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber");
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JournalNumber,Title,Content,UserNumber,EditorId,Created")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.EditorId);
            ViewData["UserNumber"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.UserNumber);
            return View(journal);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.EditorId);
            ViewData["UserNumber"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.UserNumber);
            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JournalNumber,Title,Content,UserNumber,EditorId,Created")] Journal journal)
        {
            if (id != journal.JournalNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.JournalNumber))
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
            ViewData["EditorId"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.EditorId);
            ViewData["UserNumber"] = new SelectList(_context.Set<User>(), "UserNumber", "UserNumber", journal.UserNumber);
            return View(journal);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .Include(j => j.Editor)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JournalNumber == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journal = await _context.Journal.FindAsync(id);
            _context.Journal.Remove(journal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalExists(int id)
        {
            return _context.Journal.Any(e => e.JournalNumber == id);
        }
    }
}
