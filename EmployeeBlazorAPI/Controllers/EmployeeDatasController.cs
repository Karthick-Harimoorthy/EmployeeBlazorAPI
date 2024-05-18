using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeBlazorAPI;

namespace EmployeeBlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDatasController : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeDatasController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: EmployeeDatas
        [HttpGet("getAllEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployeeData()
        {
            return await _context.EmployeeDatas.ToListAsync();
        }


        // GET: EmployeeDatas/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,Designation,Department")] EmployeeData employeeData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }

        //GET: EmployeeDatas/Edit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EmployeeDatas == null)
            {
                return NotFound();
            }

            var employeeData = await _context.EmployeeDatas.FindAsync(id);
            if (employeeData == null)
            {
                return NotFound();
            }
            return View(employeeData);
        }

        // POST: EmployeeDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpGet("{id}/{values}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpId,EmpName,Designation,Department")] EmployeeData employeeData)
        {
            if (id != employeeData.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDataExists(employeeData.EmpId))
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
            return View(employeeData);
        }

        // GET: EmployeeDatas/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EmployeeDatas == null)
            {
                return NotFound();
            }

            var employeeData = await _context.EmployeeDatas
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeData == null)
            {
                return NotFound();
            }

            return View(employeeData);
        }

        // POST: EmployeeDatas/Delete/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EmployeeDatas == null)
            {
                return Problem("Entity set 'EmployeeDBContext.EmployeeDatas'  is null.");
            }
            var employeeData = await _context.EmployeeDatas.FindAsync(id);
            if (employeeData != null)
            {
                _context.EmployeeDatas.Remove(employeeData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDataExists(string id)
        {
            return (_context.EmployeeDatas?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
