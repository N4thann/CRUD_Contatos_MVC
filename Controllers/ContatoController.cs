using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContatosMVC.Data;
using ContatosMVC.Models;

namespace ContatosMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly NZContext _context;

        public ContatoController(NZContext context)
        {
            _context = context;
        }

        // GET: Contato
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contatos.ToListAsync());
        }

        // GET: Contato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }


        // GET: Contato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Celular")] ContatoModel contatoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoModel);
        }

        // GET: Contato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos.FindAsync(id);
            if (contatoModel == null)
            {
                return NotFound();
            }
            return View(contatoModel);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Celular")] ContatoModel contatoModel)
        {
            if (id != contatoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoModelExists(contatoModel.Id))
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
            return View(contatoModel);
        }

        // GET: Contato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'NZContext.Contatos'  is null.");
            }
            var contatoModel = await _context.Contatos.FindAsync(id);
            if (contatoModel != null)
            {
                _context.Contatos.Remove(contatoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoModelExists(int id)
        {
          return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
