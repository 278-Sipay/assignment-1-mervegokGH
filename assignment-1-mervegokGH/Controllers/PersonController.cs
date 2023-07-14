using assignment_1_mervegokGH.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment_1_mervegokGH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        //IValidator is an interface that represents a validator capable of validating 
        private readonly IValidator<Person> _validator;

        //dependecy injection
        public PersonController(IValidator<Person> validator)
        {
            _validator=validator;
                
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            // represents the result of a validation operation, containing information about whether the validation was successful or not.
            var validationResult = _validator.Validate(person);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(person);
        }


    }

}

