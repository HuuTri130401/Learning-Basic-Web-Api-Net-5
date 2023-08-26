using DemoDotNetAPI.Data;
using DemoDotNetAPI.Models;
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
            return Ok(listTypes);
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
                return NotFound();
            }
        }

        [HttpPost]
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
                return Ok(type);
            }
            catch
            {
                return BadRequest();
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
                return NoContent();
            }else
            {
                return NotFound();
            }
        }
    }
}
