using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using employee_management.Data;
using employee_management.Models;

namespace employee_management.Controllers
{
    public class LeaveApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveApplications.Include(l => l.Duration).Include(l => l.Employee).Include(l => l.Leavetype).Include(l => l.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveApplications == null)
            {
                return NotFound();
            }

            var leaveApplication = await _context.LeaveApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.Leavetype)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveApplication == null)
            {
                return NotFound();
            }

            return View(leaveApplication);
        }

        // GET: LeaveApplications/Create
        public IActionResult Create()
        {
            ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x=>x.SystemCode).Where(y=>y.SystemCode.Code=="LeaveDuration"), "Id", "Description");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name");
            //ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Description");
            return View();
        }

        // POST: LeaveApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LeaveApplication leaveApplication)
        {
            //if (ModelState.IsValid)
            //{
            var PendingStatus = _context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.Code == "Pending" && y.SystemCode.Code=="leaveApprovalStatus").FirstOrDefault();//,"Id","Description");
            leaveApplication.CreatedById = "admin";
            leaveApplication.CreatedOn = DateTime.Now;
            leaveApplication.StatusId = PendingStatus.Id;

                _context.Add(leaveApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Name", leaveApplication.StatusId);
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Edit/5
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null || _context.LeaveApplications == null)
            {
                return NotFound();
            }

            var leaveApplication = await _context.LeaveApplications
                .Include(l=>l.Duration)
                .Include(l=>l.Employee)
                .Include(l=>l.Leavetype)
                .Include(l=>l.Status)
                .FirstOrDefaultAsync(m=>m.Id==id);
            if (leaveApplication == null)
            {
                return NotFound();
            }
            //ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description");
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            //ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
            //ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Name", leaveApplication.StatusId);
            return View("ApproveLeave",leaveApplication);
        }
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveLeave( LeaveApplication leaveApplication)
        {
            //if (ModelState.IsValid)
            //{
            if (leaveApplication != null)
            {
                var leave = await _context.LeaveApplications
                   .Include(l => l.Duration)
                   .Include(l => l.Employee)
                   .Include(l => l.Leavetype)
                   .Include(l => l.Status)
                   .FirstOrDefaultAsync(m => m.Id == leaveApplication.Id);
                var approvedStatus = _context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.Code == "Approved" && y.SystemCode.Code == "leaveApprovalStatus").FirstOrDefault();//,"Id","Description");

                leave.ApprovedById = "admin";
                leave.ApprovedOn = DateTime.Now;
                leave.ModfiedById = "admin";
                leave.ModifiedOn = DateTime.Now;
                leave.StatusId = approvedStatus.Id;

                _context.Update(leave);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
            // }
            ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Name", leaveApplication.StatusId);
            return View(leaveApplication);
        }
        // GET: LeaveApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveApplications == null)
            {
                return NotFound();
            }

            var leaveApplication = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplication == null)
            {
                return NotFound();
            }
            ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
            //ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Name", leaveApplication.StatusId);
            return View(leaveApplication);
        }
        // POST: LeaveApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveApplication leaveApplication)
        {
            if (id != leaveApplication.Id)
            {
                return NotFound();
            }
            var PendingStatus = _context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.Code == "Pending" && y.SystemCode.Code == "leaveApprovalStatus").FirstOrDefault();//,"Id","Description");
            
            leaveApplication.ModfiedById = "admin";
            leaveApplication.ModifiedOn = DateTime.Now;
            leaveApplication.StatusId = PendingStatus.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveApplicationExists(leaveApplication.Id))
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
            ViewData["DurationId"] = new SelectList(_context.systemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
            //ViewData["StatusId"] = new SelectList(_context.systemCodeDetails, "Id", "Name", leaveApplication.StatusId);
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveApplications == null)
            {
                return NotFound();
            }

            var leaveApplication = await _context.LeaveApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.Leavetype)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveApplication == null)
            {
                return NotFound();
            }

            return View(leaveApplication);
        }

        // POST: LeaveApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveApplications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveApplications'  is null.");
            }
            var leaveApplication = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplication != null)
            {
                _context.LeaveApplications.Remove(leaveApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveApplicationExists(int id)
        {
          return (_context.LeaveApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
