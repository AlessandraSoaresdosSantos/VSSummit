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
    [Route("api/GrupoOperacaos")]
    public class GrupoOperacaosController : Controller
    {
        private readonly DataContext _context;

        public GrupoOperacaosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GrupoOperacaos
        [HttpGet]
        public IEnumerable<GrupoOperacao> Get()
        {
            return _context.GrupoOperacao;
        }

        // GET: api/GrupoOperacaos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grupoOperacao = await _context.GrupoOperacao.SingleOrDefaultAsync(m => m.GrupoOperacaoId == id);

            if (grupoOperacao == null)
            {
                return NotFound();
            }

            return Ok(grupoOperacao);
        }

        // PUT: api/GrupoOperacaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] GrupoOperacao grupoOperacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupoOperacao.GrupoOperacaoId)
            {
                return BadRequest();
            }

            _context.Entry(grupoOperacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoOperacaoExists(id))
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

        // POST: api/GrupoOperacaos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GrupoOperacao grupoOperacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GrupoOperacao.Add(grupoOperacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoOperacao", new { id = grupoOperacao.GrupoOperacaoId }, grupoOperacao);
        }

        // DELETE: api/GrupoOperacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grupoOperacao = await _context.GrupoOperacao.SingleOrDefaultAsync(m => m.GrupoOperacaoId == id);
            if (grupoOperacao == null)
            {
                return NotFound();
            }

            _context.GrupoOperacao.Remove(grupoOperacao);
            await _context.SaveChangesAsync();

            return Ok(grupoOperacao);
        }

        private bool GrupoOperacaoExists(int id)
        {
            return _context.GrupoOperacao.Any(e => e.GrupoOperacaoId == id);
        }
    }
}