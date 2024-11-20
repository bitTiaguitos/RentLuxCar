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
    public class CredenciaisClientesController : Controller
    {
        private readonly Website_TIContext _context;

        public CredenciaisClientesController(Website_TIContext context)
        {
            _context = context;
        }

        // GET: CredenciaisClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CredenciaisCliente.ToListAsync());
        }

        // GET: CredenciaisClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credenciaisCliente = await _context.CredenciaisCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credenciaisCliente == null)
            {
                return NotFound();
            }

            return View(credenciaisCliente);
        }

        // GET: CredenciaisClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CredenciaisClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,NomeUtilizador,PasswordHash,Role")] CredenciaisCliente credenciaisCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credenciaisCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(credenciaisCliente);
        }

        // GET: CredenciaisClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credenciaisCliente = await _context.CredenciaisCliente.FindAsync(id);
            if (credenciaisCliente == null)
            {
                return NotFound();
            }
            return View(credenciaisCliente);
        }

        // POST: CredenciaisClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,NomeUtilizador,PasswordHash,Role")] CredenciaisCliente credenciaisCliente)
        {
            if (id != credenciaisCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credenciaisCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CredenciaisClienteExists(credenciaisCliente.Id))
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
            return View(credenciaisCliente);
        }

        // GET: CredenciaisClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credenciaisCliente = await _context.CredenciaisCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credenciaisCliente == null)
            {
                return NotFound();
            }

            return View(credenciaisCliente);
        }

        // POST: CredenciaisClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credenciaisCliente = await _context.CredenciaisCliente.FindAsync(id);
            if (credenciaisCliente != null)
            {
                _context.CredenciaisCliente.Remove(credenciaisCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CredenciaisClienteExists(int id)
        {
            return _context.CredenciaisCliente.Any(e => e.Id == id);
        }
    }
}
