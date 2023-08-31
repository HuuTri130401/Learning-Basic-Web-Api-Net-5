using DemoDotNetAPI.Models;
using DemoDotNetAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesWithVMController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public TypesWithVMController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_typeRepository.GetAllTypes());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var type = _typeRepository.GetTypeById(id);
                if (type != null)
                {
                    return Ok(type);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateType(int id, TypeVM typeVM) //fill model to update
        {
            if(id != typeVM.TypeId)
            {
                return BadRequest();
            }
            try
            {
                _typeRepository.UpdateType(typeVM);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _typeRepository.DeleteType(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult Add(TypeModel typeModel)
        {
            try
            {
                return Ok(_typeRepository.NewType(typeModel));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
