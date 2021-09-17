using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcComercio.Data;
using MvcComercio.Models;

namespace MvcComercio.Controllers
{
    public class CancionesController : Controller
    {
        private readonly MvcComercioContexto _context;

        public CancionesController(MvcComercioContexto context)
        {
            _context = context;
        }

        // GET: Canciones
        public async Task<IActionResult> Index()
        {
            var mvcComercioContexto = _context.Canciones.Include(c => c.Disco);
            return View(await mvcComercioContexto.ToListAsync());
        }

        // GET: Canciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones
                .Include(c => c.Disco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // GET: Canciones/Create
        public IActionResult Create()
        {
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco");
            return View();
        }

        // POST: Canciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Duracion,DiscoId")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", cancion.DiscoId);
            return View(cancion);
        }

        // GET: Canciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", cancion.DiscoId);
            return View(cancion);
        }

        // POST: Canciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Duracion,DiscoId")] Cancion cancion)
        {
            if (id != cancion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancionExists(cancion.Id))
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
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", cancion.DiscoId);
            return View(cancion);
        }

        // GET: Canciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones
                .Include(c => c.Disco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionExists(int id)
        {
            return _context.Canciones.Any(e => e.Id == id);
        }
    }
}
