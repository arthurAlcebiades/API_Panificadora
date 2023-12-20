using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_Panificadora.Models;

namespace API_Panificadora.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppContexto _context;

        public ClienteController(AppContexto context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
              return _context.cliente != null ? 
                          View(_context.cliente.ToList()) :
                          Problem("Entity set 'AppContexto.cliente'  is null.");
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var clienteModelView = await _context.cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModelView == null)
            {
                return NotFound();
            }

            return View(clienteModelView);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,CPFCNPJ,Contato,Endereco")] ClienteModelView clienteModelView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteModelView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModelView);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var clienteModelView = await _context.cliente.FindAsync(id);
            if (clienteModelView == null)
            {
                return NotFound();
            }
            return View(clienteModelView);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,CPFCNPJ,Contato,Endereco")] ClienteModelView clienteModelView)
        {
            if (id != clienteModelView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModelView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelViewExists(clienteModelView.Id))
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
            return View(clienteModelView);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var clienteModelView = await _context.cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModelView == null)
            {
                return NotFound();
            }

            return View(clienteModelView);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cliente == null)
            {
                return Problem("Entity set 'AppContexto.cliente'  is null.");
            }
            var clienteModelView = await _context.cliente.FindAsync(id);
            if (clienteModelView != null)
            {
                _context.cliente.Remove(clienteModelView);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelViewExists(int id)
        {
          return (_context.cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
