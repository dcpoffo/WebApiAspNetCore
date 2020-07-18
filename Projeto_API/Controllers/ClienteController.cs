using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projeto_API.Context;
using Projeto_API.Models;

namespace Projeto_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ContextApp _context;

        public ClienteController(ContextApp context)
        {
            this._context = context;
        }
        public IEnumerable<Cliente> Get()
        {
            //return "Controle do cliente acessado!";
            return this._context.Cliente.ToList();
            //return this._context.Cliente.ToList().OrderBy(s => s.Nome);
            //return this._context.Cliente.ToList().OrderByDescending(s => s.Id);
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var cliente = this._context.Cliente.FirstOrDefault(c => c.Id == id);
            return cliente;                
        }
    }
}