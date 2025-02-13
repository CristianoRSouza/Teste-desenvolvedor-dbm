using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Interfaces.Services;

namespace TesteDevFullStackDbm.Controllers
{
    public class ProtocolController : Controller
    {
        private readonly IServiceProtocol _serviceProtocol;
        

        public ProtocolController(IServiceProtocol serviceProtocol)
        {
            _serviceProtocol = serviceProtocol;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serviceProtocol.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _serviceProtocol.Get(id);
            if (protocol == null)
            {
                return NotFound();
            }

            return View(protocol);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clientes = await _serviceProtocol.GetClientes();
            ViewBag.Status = await _serviceProtocol.GetStatus();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProtocolDto protocol)
        {
            if (ModelState.IsValid)
            {

                await _serviceProtocol.Add(protocol);
                return RedirectToAction(nameof(Index));
            }
            return View(protocol);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _serviceProtocol.Get(id);
            if (protocol == null)
            {
                return NotFound();
            }
            return View(protocol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProtocol,Titulo,Descricao,DataAbertura,DataFechamento,ClienteId,ProtocolStatusId")] ProtocolDto protocol)
        {
            if (id != protocol.IdProtocol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _serviceProtocol.Update(protocol);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao editar o protocolo", ex);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(protocol);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var protocol = await _serviceProtocol.Get(id);
            if (protocol == null)
            {
                return NotFound();
            }

            return View(protocol);
        }

        // POST: Protocol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var protocol = await _serviceProtocol.Get(id);
            if (protocol != null)
            {
                await _serviceProtocol.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
