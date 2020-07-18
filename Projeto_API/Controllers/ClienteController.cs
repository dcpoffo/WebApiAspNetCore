using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("id/{id}")]
        public Cliente Get(int id)
        {
            var cliente = this._context.Cliente.FirstOrDefault(c => c.Id == id);
            return cliente;                
        }

        [HttpGet("nome/{nome}")]
        public Cliente Get(string nome)
        {
            var cliente = this._context.Cliente.FirstOrDefault(c => c.Nome == nome);
            return cliente;                
        }

        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                this._context.Cliente.Add(cliente);
                this._context.SaveChanges();
               return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (cliente.Id == id)
            {
                this._context.Entry(cliente).State = EntityState.Modified;
                this._context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
             var cliente = this._context.Cliente.FirstOrDefault(c => c.Id == id);
             if (cliente != null)
             {
                 this._context.Cliente.Remove(cliente);
                 this._context.SaveChanges();
                 return Ok();
             }
             else
             {
                 return BadRequest();
             }
        }
    }
}