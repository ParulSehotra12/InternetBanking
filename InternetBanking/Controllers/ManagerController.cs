using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetBanking.Data;
using InternetBanking.Models;

namespace InternetBanking.Controllers
{
    public class ManagerController : Controller
    {
        private readonly UserContext _context;
        public IActionResult CustomerList()
        {
            try
            {

                var CustList = _context.registration.ToList();
                return View(CustList);
            }
            catch (Exception ex)
            {
                return View();
            }


        }
        public ManagerController(UserContext context)
        {
            _context = context;
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
              return _context.registration != null ? 
                          View(await _context.registration.ToListAsync()) :
                          Problem("Entity set 'InternetBankingContext.RegisterViewModel'  is null.");
        }

        // GET: Manager/Details/5
        /*
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.registration == null)
            {
                return NotFound();
            }

            var registerViewModel = await _context.registration
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (registerViewModel == null)
            {
                return NotFound();
            }

            return View(registerViewModel);
        }
        
        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,SBAccountNumber,CIFNumber,BranchCode,RegisteredMobileNo,UStatus")] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerViewModel);
        }
        */
        // GET: Manager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.registration == null)
            {
                return NotFound();
            }

            var registerViewModel = await _context.registration.FindAsync(id);
            if (registerViewModel == null)
            {
                return NotFound();
            }
            return View(registerViewModel);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,SBAccountNumber,CIFNumber,BranchCode,RegisteredMobileNo,UStatus")] RegisterViewModel registerViewModel)
        {
            if (id != registerViewModel.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterViewModelExists(registerViewModel.RequestID))
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
            return View(registerViewModel);
        }

        // GET: Manager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.registration == null)
            {
                return NotFound();
            }

            var registerViewModel = await _context.registration
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (registerViewModel == null)
            {
                return NotFound();
            }

            return View(registerViewModel);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.registration == null)
            {
                return Problem("Entity set 'InternetBankingContext.RegisterViewModel'  is null.");
            }
            var registerViewModel = await _context.registration.FindAsync(id);
            if (registerViewModel != null)
            {
                _context.registration.Remove(registerViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterViewModelExists(int id)
        {
          return (_context.registration?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
