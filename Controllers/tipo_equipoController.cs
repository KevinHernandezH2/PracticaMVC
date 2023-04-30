using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class tipo_equipoController : Controller
    {
        private readonly equiposDbContext _context;

        public tipo_equipoController(equiposDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
              return _context.tipo_equipo != null ? 
                          View(await _context.tipo_equipo.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.tipo_equipo'  is null.");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipo_equipo == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_equipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }

            return View(tipo_equipo);
        }

       
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo_equipo,descripcion,estado")] tipo_equipo tipo_equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_equipo);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipo_equipo == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_equipo.FindAsync(id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }
            return View(tipo_equipo);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipo_equipo,descripcion,estado")] tipo_equipo tipo_equipo)
        {
            if (id != tipo_equipo.id_tipo_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tipo_equipoExists(tipo_equipo.id_tipo_equipo))
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
            return View(tipo_equipo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipo_equipo == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_equipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }

            return View(tipo_equipo);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipo_equipo == null)
            {
                return Problem("Entity set 'equiposDbContext.tipo_equipo'  is null.");
            }
            var tipo_equipo = await _context.tipo_equipo.FindAsync(id);
            if (tipo_equipo != null)
            {
                _context.tipo_equipo.Remove(tipo_equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tipo_equipoExists(int id)
        {
          return (_context.tipo_equipo?.Any(e => e.id_tipo_equipo == id)).GetValueOrDefault();
        }
    }
}
