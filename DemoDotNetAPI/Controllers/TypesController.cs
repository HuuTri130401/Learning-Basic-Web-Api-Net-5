using DemoDotNetAPI.Data;
using DemoDotNetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemoDotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public TypesController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTypes()
        {
            var listTypes = _context.Types.ToList();
            return Ok(listTypes); //status 200
        }

        [HttpGet("{id}")]
        public IActionResult GetTypeById(int id)
        {
            var type = _context.Types.SingleOrDefault(tp => tp.TypeId == id);
            if (type != null)
            {
                return Ok(type);
            }
            else
            {
                return NotFound(); // status 404
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNewType(TypeModel typeModel)
        {
            try
            {
                var type = new Type
                {
                    TypeName = typeModel.TypeName,
                };
                _context.Add(type);
                _context.SaveChanges(); //Update 
                //return Ok(type);
                return StatusCode(StatusCodes.Status201Created, type);
            }
            catch
            {
                return BadRequest(); //status: 400
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTypeById(int id, TypeModel typeModel)
        {
            var type = _context.Types.SingleOrDefault(tp => tp.TypeId == id);
            if (type != null)
            {
                type.TypeName = typeModel.TypeName;
                _context.SaveChanges();
                return NoContent(); //204, not need return body
            }else
            {
                return NotFound(); //404
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTypeById(int id)
        {
            var type = _context.Types.FirstOrDefault(tp => tp.TypeId == id);
            if(type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges(); //save in DB
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    
    }
}
