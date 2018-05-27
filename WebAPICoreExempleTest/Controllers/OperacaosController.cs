using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICoreExempleTest;
using WebAPICoreExempleTest.Models;

namespace WebAPICoreExempleTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Operacaos")]
    public class OperacaosController : Controller
    {
        private readonly DataContext _context;

        public OperacaosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Operacaos
        [HttpGet]
        public IEnumerable<Operacao> Get()
        {
            return _context.Operacao;
        }

        // GET: api/Operacaos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operacao = await _context.Operacao.SingleOrDefaultAsync(m => m.OperacaoId == id);

            if (operacao == null)
            {
                return NotFound();
            }

            return Ok(operacao);
        }

        // PUT: api/Operacaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Operacao operacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operacao.OperacaoId)
            {
                return BadRequest();
            }

            _context.Entry(operacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Operacaos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Operacao operacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Operacao.Add(operacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacao", new { id = operacao.OperacaoId }, operacao);
        }

        // DELETE: api/Operacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operacao = await _context.Operacao.SingleOrDefaultAsync(m => m.OperacaoId == id);
            if (operacao == null)
            {
                return NotFound();
            }

            _context.Operacao.Remove(operacao);
            await _context.SaveChangesAsync();

            return Ok(operacao);
        }

        private bool OperacaoExists(int id)
        {
            return _context.Operacao.Any(e => e.OperacaoId == id);
        }
    }
}