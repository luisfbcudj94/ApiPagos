using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPagos.Data;
using ApiPagos.Models;
using System.Collections;

namespace ApiPagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pagosController : ControllerBase
    {
        private readonly ApiPagosContext _context;

        public pagosController(ApiPagosContext context)
        {
            _context = context;
        }

        // GET: api/pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pagos>>> Getpagos()
        {
            return await _context.pagos.ToListAsync();
        }

        // GET: api/pagos/5
        [HttpGet("facturar/{customer}")]
        public ActionResult<IEnumerable<string>> Getpagos(string customer)
        {
            //var pagos = _context.pagos.FirstOrDefault(p => p.Customer == customer);

            IEnumerable<pagos> pagos = _context.pagos.Where(p => p.Customer == customer);

            //var totalCount = pagos.TotalPrice;
            double sum = 0;
            foreach (var item in pagos)
            {
                //Console.WriteLine("Result "+item.TotalPrice.ToString());
                sum = item.TotalPrice + sum;
            }

            return new string[]  { sum.ToString() };
        }

        //POST Pedidos
        [HttpPost("pedidos")]
        public async Task<ActionResult<pagos>> Postpedidos(pedidos pedidos)
        {
            _context.pedidos.Add(pedidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpagos", new { id = pedidos.Id }, pedidos);

        }


        // PUT: api/pagos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpagos(int id, pagos pagos)
        {
            if (id != pagos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pagosExists(id))
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

        //POST: api/pagos
        //To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<pagos>> Postpagos(pagos pagos)
        {
            _context.pagos.Add(pagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpagos", new { id = pagos.Id }, pagos);
        }

        // DELETE: api/pagos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<pagos>> Deletepagos(int id)
        {
            var pagos = await _context.pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return pagos;
        }

        private bool pagosExists(int id)
        {
            return _context.pagos.Any(e => e.Id == id);
        }
    }
}
