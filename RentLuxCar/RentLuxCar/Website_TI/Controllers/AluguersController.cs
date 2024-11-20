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
    public class AluguersController : Controller
    {
        private readonly Website_TIContext _context;

        public AluguersController(Website_TIContext context)
        {
            _context = context;
        }

        // GET: Aluguers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluguer.ToListAsync());
        }

        // GET: Aluguers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // GET: Aluguers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluguers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarroAlugado,DataDeAluguer,InicioAluguer,FimAluguer,EntregaViaturaAluguer,IdCliente")] Aluguer aluguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluguer);
        }

        // GET: Aluguers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer.FindAsync(id);
            if (aluguer == null)
            {
                return NotFound();
            }
            return View(aluguer);
        }

        // POST: Aluguers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarroAlugado,DataDeAluguer,InicioAluguer,FimAluguer,EntregaViaturaAluguer,IdCliente")] Aluguer aluguer)
        {
            if (id != aluguer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguerExists(aluguer.Id))
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
            return View(aluguer);
        }

        // GET: Aluguers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // POST: Aluguers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguer = await _context.Aluguer.FindAsync(id);
            if (aluguer != null)
            {
                _context.Aluguer.Remove(aluguer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguerExists(int id)
        {
            return _context.Aluguer.Any(e => e.Id == id);
        }
    }
}
