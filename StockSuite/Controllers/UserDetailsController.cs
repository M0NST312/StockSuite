using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockSuite.Models;
using StockSuite.MomoAPI;
using StockSuite.SSContext;
using StockSuite.Utilities;

namespace StockSuite.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly SSDBContext _context;

        public UserDetailsController(SSDBContext context)
        {
            _context = context;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserDetails.ToListAsync());
        }
        public async Task<IActionResult> PaymentRequest()
        {
            return View();
        }
        public async Task<IActionResult> LoanRequest()
        {
            return View();
        }

        public async Task<IActionResult> SavingsRequest()
        {
            return View();
        }
        public async Task<IActionResult> PaySavings(string item)
        {
            RequestToPay requestToPay = new RequestToPay();
            var status = await requestToPay.SendPayRequest(item);
            RequestToPayAttributes paymentDetails = status;

            var user = await _context.UserDetails.FirstOrDefaultAsync();
            Transaction transaction = new Transaction()
            {
                Amount = float.Parse(paymentDetails.amount),
                Reference = item,
                Type = "Deposit",
                UserDetails = user,
                CreatedDate = DateTime.Now,
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            // return View();
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Pay(string item)
        {
            RequestToPay requestToPay = new RequestToPay();
            var status = await  requestToPay.SendPayRequest(item);
            RequestToPayAttributes paymentDetails = status;

            var user = await _context.UserDetails.FirstOrDefaultAsync();
            Transaction transaction = new Transaction()
            {
                Amount = float.Parse(paymentDetails.amount),
                Reference = item,
                Type = "Deposit",
                UserDetails = user,
                CreatedDate = DateTime.Now,                
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return RedirectToAction( "Index", "Home");
           // return View();
        }
        // GET: UserDetails/Details/5
        public async Task<IActionResult> Withdraw(string item)
        {
            //RequestToPay requestToPay = new RequestToPay();
            //var status = await requestToPay.SendPayRequest(item);
            //RequestToPayAttributes paymentDetails = status;
            Disbursement disburse = new Disbursement();
            var status = await disburse.DisbursementRequest("Quick Loan");
            DisbursementStatusPayload withdrawal = status;

            var user = await _context.UserDetails.FirstOrDefaultAsync();
            Transaction transaction = new Transaction()
            {
                Amount = float.Parse(withdrawal.amount),
                Reference = item,
                Type = "Withdraw",
                UserDetails = user,
                CreatedDate = DateTime.Now,
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            // return View();
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Active,NationalID,PhoneNumber")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Active,NationalID,PhoneNumber")] UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailsExists(userDetails.Id))
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
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDetails == null)
            {
                return Problem("Entity set 'SSDBContext.UserDetails'  is null.");
            }
            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailsExists(int id)
        {
          return _context.UserDetails.Any(e => e.Id == id);
        }
    }
}
