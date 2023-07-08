using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryApp.Context;
using DeliveryApp.Models;

namespace DeliveryApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly CafeSelectoContext _context;

        public ClienteController(CafeSelectoContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync()); //buscar tolistasync
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create() //recibe el formulario
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Dni,Nombre,Apellido,Telefono,Email,Direccion, CodPostal")] Cliente cliente) ////envia el formulario
        {
            if (ModelState.IsValid)
            {
                var existingCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Dni == cliente.Dni);

                if (existingCliente != null)
                {
                    // Cliente con el mismo DNI ya existe en la base de datos
                    ModelState.AddModelError("Dni", "Ya existe un cliente con el mismo DNI.");
                    return View(cliente);
                }
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));                
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Dni,Nombre,Apellido,Telefono,Email,Direccion, CodPostal")] Cliente cliente)
        { 
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid) //En este código, se realiza una búsqueda en la base de datos utilizando el método FirstOrDefaultAsync para 
            {                       //encontrar un cliente distinto al que se está editando pero con el mismo DNI. Si se encuentra un cliente con el
                                    // mismo DNI, se agrega un error al modelo (ModelState) indicando que ya existe otro cliente con ese DNI y se devuelve 
                                    //la vista con el cliente para mostrar el mensaje de error al usuario.

                //Si no se encuentra otro cliente con el mismo DNI, se procede a actualizar los datos del cliente en la base de datos y se redirige al método Index para mostrar la lista actualizada de clientes.
                //Recuerda que este código asume que estás utilizando Entity Framework y que Clientes es el DbSet correspondiente a la tabla de clientes en tu contexto de base de datos (_context).

                // Buscar cliente por DNI en la base de datos excluyendo el cliente actual
                var existingCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Dni == cliente.Dni && c.IdCliente != cliente.IdCliente);

                if (existingCliente != null)
                {
                    // Cliente con el mismo DNI ya existe en la base de datos
                    ModelState.AddModelError("Dni", "Ya existe otro cliente con el mismo DNI.");
                    return View(cliente);
                }
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
