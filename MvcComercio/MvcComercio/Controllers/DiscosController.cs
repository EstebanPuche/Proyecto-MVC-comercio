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
    public class DiscosController : Controller
    {
        private readonly MvcComercioContexto _context;

        public DiscosController(MvcComercioContexto context)
        {
            _context = context;
        }

        // GET: Discos
        public async Task<IActionResult> Index()
        {
            var mvcComercioContexto = _context.Discos.Include(d => d.Artista);
            return View(await mvcComercioContexto.ToListAsync());
        }

        // GET: Discos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos
                .Include(d => d.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disco == null)
            {
                return NotFound();
            }

            return View(disco);
        }

        // GET: Discos/Create
        public IActionResult Create()
        {
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Apellidos");
            return View();
        }

        // POST: Discos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDisco,FechaPublicacion,Precio,ImagenPortada,ArtistaId")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Apellidos", disco.ArtistaId);
            return View(disco);
        }

        // GET: Discos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos.FindAsync(id);
            if (disco == null)
            {
                return NotFound();
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Apellidos", disco.ArtistaId);
            return View(disco);
        }

        // POST: Discos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDisco,FechaPublicacion,Precio,ImagenPortada,ArtistaId")] Disco disco)
        {
            if (id != disco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoExists(disco.Id))
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
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Apellidos", disco.ArtistaId);
            return View(disco);
        }

        // GET: Discos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos
                .Include(d => d.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disco == null)
            {
                return NotFound();
            }

            return View(disco);
        }

        // POST: Discos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disco = await _context.Discos.FindAsync(id);
            _context.Discos.Remove(disco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscoExists(int id)
        {
            return _context.Discos.Any(e => e.Id == id);
        }
    }
}
