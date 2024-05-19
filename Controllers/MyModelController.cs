using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNamespace.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNamespace.Controllers
{
    [Route("api/arac")]
    [ApiController]
    public class MyModelController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MyModelController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/MyModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyModel>>> GetMyModels()
        {
            return await _context.Araclar.ToListAsync();
        }

        // GET: api/MyModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyModel>> GetMyModel(int id)
        {
            var myModel = await _context.Araclar.FindAsync(id);

            if (myModel == null)
            {
                return NotFound();
            }

            return myModel;
        }

        // POST: api/MyModel
        [HttpPost]
        public async Task<ActionResult<MyModel>> PostMyModel(MyModel myModel)
        {
            _context.Araclar.Add(myModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMyModel), new { id = myModel.Id }, myModel);
        }

        // PUT: api/MyModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyModel(int id, MyModel myModel)
        {
            if (id != myModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(myModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyModelExists(id))
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

        // DELETE: api/MyModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyModel(int id)
        {
            var myModel = await _context.Araclar.FindAsync(id);
            if (myModel == null)
            {
                return NotFound();
            }

            _context.Araclar.Remove(myModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyModelExists(int id)
        {
            return _context.Araclar.Any(e => e.Id == id);
        }
    }
}