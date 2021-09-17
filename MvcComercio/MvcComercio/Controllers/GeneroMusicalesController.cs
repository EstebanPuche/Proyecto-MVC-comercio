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
    public class GeneroMusicalesController : Controller
    {
        private readonly MvcComercioContexto _context;

        public GeneroMusicalesController(MvcComercioContexto context)
        {
            _context = context;
        }

        // GET: GeneroMusicales
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneroMusicales.ToListAsync());
        }

        // GET: GeneroMusicales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoMusical = await _context.GeneroMusicales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generoMusical == null)
            {
                return NotFound();
            }

            return View(generoMusical);
        }

        // GET: GeneroMusicales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneroMusicales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Genero,ImagenGenero")] GeneroMusical generoMusical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generoMusical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generoMusical);
        }

        // GET: GeneroMusicales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoMusical = await _context.GeneroMusicales.FindAsync(id);
            if (generoMusical == null)
            {
                return NotFound();
            }
            return View(generoMusical);
        }

        // POST: GeneroMusicales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Genero,ImagenGenero")] GeneroMusical generoMusical)
        {
            if (id != generoMusical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generoMusical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroMusicalExists(generoMusical.Id))
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
            return View(generoMusical);
        }

        // GET: GeneroMusicales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoMusical = await _context.GeneroMusicales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generoMusical == null)
            {
                return NotFound();
            }

            return View(generoMusical);
        }

        // POST: GeneroMusicales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generoMusical = await _context.GeneroMusicales.FindAsync(id);
            _context.GeneroMusicales.Remove(generoMusical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroMusicalExists(int id)
        {
            return _context.GeneroMusicales.Any(e => e.Id == id);
        }
    }
}
