using FBTarjeta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public TarjetaController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: TarjetaController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTarjetas = await _context.TarjetaCredito.ToListAsync();
                return Ok(listTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: TarjetaController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: TarjetaController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (id != tarjeta.Id)
                {
                    return NotFound();
                }

                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta fue actualizada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //GET: TarjetaController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredito.FindAsync(id);
                if(tarjeta == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.TarjetaCredito.Remove(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta fue eliminada con exito"});
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
}
