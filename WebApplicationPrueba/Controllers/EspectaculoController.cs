using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationPrueba.Context;
using WebApplicationPrueba.Models;

namespace WebApplicationPrueba.Controllers
{
    public class EspectaculoController : Controller
    {
        private readonly ForoDatabaseContext _context;

        public EspectaculoController(ForoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Espectaculo
        public async Task<IActionResult> Index()
        {
              return _context.Espectaculo != null ? 
                          View(await _context.Espectaculo.ToListAsync()) :
                          Problem("Entity set 'ForoDatabaseContext.Espectaculo'  is null.");
        }

        // GET: Espectaculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Espectaculo == null)
            {
                return NotFound();
            }

            var espectaculo = await _context.Espectaculo
                .FirstOrDefaultAsync(m => m.idEspectaculo == id);
            if (espectaculo == null)
            {
                return NotFound();
            }

            return View(espectaculo);
        }

        // GET: Espectaculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Espectaculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,direccion,fecha,visibilidad,idEspectaculo")] Espectaculo espectaculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espectaculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(espectaculo);
        }

        // GET: Espectaculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Espectaculo == null)
            {
                return NotFound();
            }

            var espectaculo = await _context.Espectaculo.FindAsync(id);
            if (espectaculo == null)
            {
                return NotFound();
            }
            return View(espectaculo);
        }

        // POST: Espectaculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nombre,direccion,fecha,visibilidad,idEspectaculo")] Espectaculo espectaculo)
        {
            if (id != espectaculo.idEspectaculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espectaculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspectaculoExists(espectaculo.idEspectaculo))
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
            return View(espectaculo);
        }

        // GET: Espectaculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Espectaculo == null)
            {
                return NotFound();
            }

            var espectaculo = await _context.Espectaculo
                .FirstOrDefaultAsync(m => m.idEspectaculo == id);
            if (espectaculo == null)
            {
                return NotFound();
            }

            return View(espectaculo);
        }

        // POST: Espectaculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Espectaculo == null)
            {
                return Problem("Entity set 'ForoDatabaseContext.Espectaculo'  is null.");
            }
            var espectaculo = await _context.Espectaculo.FindAsync(id);
            if (espectaculo != null)
            {
                _context.Espectaculo.Remove(espectaculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspectaculoExists(int id)
        {
          return (_context.Espectaculo?.Any(e => e.idEspectaculo == id)).GetValueOrDefault();
        }
    }
}
