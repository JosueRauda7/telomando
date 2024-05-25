using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models;

namespace Telomando.Controllers
{
    public class ModeloTransportesController : Controller
    {
        private readonly TelomandofinalContext _context;

        public ModeloTransportesController(TelomandofinalContext context)
        {
            _context = context;
        }

        // GET: ModeloTransportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeloTransportes.ToListAsync());
        }

        // GET: ModeloTransportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloTransporte = await _context.ModeloTransportes
                .FirstOrDefaultAsync(m => m.Idmodelotransporte == id);
            if (modeloTransporte == null)
            {
                return NotFound();
            }

            return View(modeloTransporte);
        }

        // GET: ModeloTransportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmodelotransporte,Nombre,Anio,FechaRegistro,Activo,Eliminado")] ModeloTransporte modeloTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloTransporte);
        }

        // GET: ModeloTransportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloTransporte = await _context.ModeloTransportes.FindAsync(id);
            if (modeloTransporte == null)
            {
                return NotFound();
            }
            return View(modeloTransporte);
        }

        // POST: ModeloTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmodelotransporte,Nombre,Anio,FechaRegistro,Activo,Eliminado")] ModeloTransporte modeloTransporte)
        {
            if (id != modeloTransporte.Idmodelotransporte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloTransporteExists(modeloTransporte.Idmodelotransporte))
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
            return View(modeloTransporte);
        }

        // GET: ModeloTransportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloTransporte = await _context.ModeloTransportes
                .FirstOrDefaultAsync(m => m.Idmodelotransporte == id);
            if (modeloTransporte == null)
            {
                return NotFound();
            }

            return View(modeloTransporte);
        }

        // POST: ModeloTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloTransporte = await _context.ModeloTransportes.FindAsync(id);
            if (modeloTransporte != null)
            {
                _context.ModeloTransportes.Remove(modeloTransporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloTransporteExists(int id)
        {
            return _context.ModeloTransportes.Any(e => e.Idmodelotransporte == id);
        }
    }
}
