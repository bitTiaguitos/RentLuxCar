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
    public class ViaturasController : Controller
    {
        private readonly Website_TIContext _context;

        public ViaturasController(Website_TIContext context)
        {
            _context = context;
        }

        // GET: Viaturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viaturas.ToListAsync());
        }

        // GET: Viaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaturas = await _context.Viaturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaturas == null)
            {
                return NotFound();
            }

            return View(viaturas);
        }

        // GET: Viaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Tipo,Ano,PrecoHora,TipoAluguer")] Viaturas viaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viaturas);
        }

        // GET: Viaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaturas = await _context.Viaturas.FindAsync(id);
            if (viaturas == null)
            {
                return NotFound();
            }
            return View(viaturas);
        }

        // POST: Viaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Tipo,Ano,PrecoHora,TipoAluguer")] Viaturas viaturas)
        {
            if (id != viaturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViaturasExists(viaturas.Id))
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
            return View(viaturas);
        }

        // GET: Viaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaturas = await _context.Viaturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaturas == null)
            {
                return NotFound();
            }

            return View(viaturas);
        }

        // POST: Viaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viaturas = await _context.Viaturas.FindAsync(id);
            if (viaturas != null)
            {
                _context.Viaturas.Remove(viaturas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViaturasExists(int id)
        {
            return _context.Viaturas.Any(e => e.Id == id);
        }
    }
}
