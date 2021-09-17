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
    public class DetalleFacturasController : Controller
    {
        private readonly MvcComercioContexto _context;

        public DetalleFacturasController(MvcComercioContexto context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            var mvcComercioContexto = _context.DetalleFacturas.Include(d => d.Disco).Include(d => d.Factura);
            return View(await mvcComercioContexto.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.Disco)
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco");
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiscoId,FacturaId")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", detalleFactura.DiscoId);
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", detalleFactura.DiscoId);
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiscoId,FacturaId")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.Id))
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
            ViewData["DiscoId"] = new SelectList(_context.Discos, "Id", "NombreDisco", detalleFactura.DiscoId);
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.Disco)
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            _context.DetalleFacturas.Remove(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFacturas.Any(e => e.Id == id);
        }
    }
}
