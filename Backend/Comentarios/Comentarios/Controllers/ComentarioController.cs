using System;
using System.Collections.Generic;
using System.Linq;
using Comentarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ComentarioController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET api/<ComentarioController>
        [HttpGet]
        public ActionResult<List<Comentario>>Get()
        {
            try
            {
                var listaComentarios = _applicationDbContext.Comentario.ToList();
                return Ok(listaComentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> Get(int id)
        {
            try
            {
                var comentario = _applicationDbContext.Comentario.Find(id);
                if (comentario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(comentario);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Comentario comentario)
        {
            try
            {
                _applicationDbContext.Add(comentario);
                _applicationDbContext.SaveChanges();
                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (id != comentario.Id)
                {
                    return BadRequest();
                }
                
                _applicationDbContext.Entry(comentario).State = EntityState.Modified;
                _applicationDbContext.Update(comentario);
                _applicationDbContext.SaveChanges();
                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var comentario = _applicationDbContext.Comentario.Find(id);
                if (comentario == null)
                {
                    return NotFound();
                }

                _applicationDbContext.Remove(comentario);
                _applicationDbContext.SaveChanges();
                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}