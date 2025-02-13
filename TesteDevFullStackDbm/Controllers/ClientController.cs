using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Interfaces.Services;

namespace TesteDevFullStackDbm.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceClient _serviceClient;
        private readonly IServiceProtocol _serviceProtocol;

        public ClientController(IServiceClient serviceClient, IServiceProtocol serviceProtocol)
        {
            _serviceClient = serviceClient;
            _serviceProtocol = serviceProtocol;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _serviceClient.GetClientWithDetails();
            return View(clients);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) 
            {
                return NotFound();
            }

            var client = await _serviceClient.GetUser(id); 
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nome,Email,Telefone,Endereco")] ClientDto client)
        {
            if (ModelState.IsValid)
            {
                await _serviceClient.AddUser(client); 
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var client = await _serviceClient.GetUser(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nome,Email,Telefone,Endereco")] ClientDto client)
        {
            if (id != client.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceClient.UpdateUser(client); 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar o cliente: " + ex.Message);
                    return View(client);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var client = await _serviceClient.GetUser(id); 
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceClient.DeleteUser(id); 
            return RedirectToAction(nameof(Index));
        }
    }
}
