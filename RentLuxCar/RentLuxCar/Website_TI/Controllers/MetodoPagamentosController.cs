using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_TI.Data;
using Website_TI.Models.DTO;

namespace Website_TI.Controllers
{
    public class MetodoPagamentosController : Controller
    {
        private readonly Website_TIContext _context;

        public MetodoPagamentosController(Website_TIContext context)
        {
            _context = context;
        }

        // GET: MetodoPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodoPagamentos.ToListAsync());
        }

        // GET: MetodoPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentos = await _context.MetodoPagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoPagamentos == null)
            {
                return NotFound();
            }

            return View(metodoPagamentos);
        }

        // GET: MetodoPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormaPagamento")] MetodoPagamentos metodoPagamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPagamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoPagamentos);
        }

        // GET: MetodoPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentos = await _context.MetodoPagamentos.FindAsync(id);
            if (metodoPagamentos == null)
            {
                return NotFound();
            }
            return View(metodoPagamentos);
        }

        // POST: MetodoPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormaPagamento")] MetodoPagamentos metodoPagamentos)
        {
            if (id != metodoPagamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPagamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagamentosExists(metodoPagamentos.Id))
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
            return View(metodoPagamentos);
        }

        // GET: MetodoPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentos = await _context.MetodoPagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoPagamentos == null)
            {
                return NotFound();
            }

            return View(metodoPagamentos);
        }

        // POST: MetodoPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoPagamentos = await _context.MetodoPagamentos.FindAsync(id);
            if (metodoPagamentos != null)
            {
                _context.MetodoPagamentos.Remove(metodoPagamentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagamentosExists(int id)
        {
            return _context.MetodoPagamentos.Any(e => e.Id == id);
        }
    }
}
