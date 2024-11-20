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
    public class TipoDeViaturasController : Controller
    {
        private readonly Website_TIContext _context;

        public TipoDeViaturasController(Website_TIContext context)
        {
            _context = context;
        }

        // GET: TipoDeViaturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeViaturas.ToListAsync());
        }

        // GET: TipoDeViaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeViaturas = await _context.TipoDeViaturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeViaturas == null)
            {
                return NotFound();
            }

            return View(tipoDeViaturas);
        }

        // GET: TipoDeViaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeViaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,ValorFixoPorTipo")] TipoDeViaturas tipoDeViaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeViaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeViaturas);
        }

        // GET: TipoDeViaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeViaturas = await _context.TipoDeViaturas.FindAsync(id);
            if (tipoDeViaturas == null)
            {
                return NotFound();
            }
            return View(tipoDeViaturas);
        }

        // POST: TipoDeViaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,ValorFixoPorTipo")] TipoDeViaturas tipoDeViaturas)
        {
            if (id != tipoDeViaturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeViaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeViaturasExists(tipoDeViaturas.Id))
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
            return View(tipoDeViaturas);
        }

        // GET: TipoDeViaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeViaturas = await _context.TipoDeViaturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeViaturas == null)
            {
                return NotFound();
            }

            return View(tipoDeViaturas);
        }

        // POST: TipoDeViaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeViaturas = await _context.TipoDeViaturas.FindAsync(id);
            if (tipoDeViaturas != null)
            {
                _context.TipoDeViaturas.Remove(tipoDeViaturas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeViaturasExists(int id)
        {
            return _context.TipoDeViaturas.Any(e => e.Id == id);
        }
    }
}
