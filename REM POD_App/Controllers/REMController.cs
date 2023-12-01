using Microsoft.AspNetCore.Mvc;
using REM_POD_App.files;

namespace REM_POD_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class REM_POD_Controller : Controller
    {
        private Repository _data;
        public REM_POD_Controller(Repository repo)
        {
            _data = repo;
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetAll(string? orderBy = null)
        //{
        //    try
        //    {


        //        IEnumerable<Model> model;

        //        //if (string.IsNullOrEmpty(orderBy))
        //        //{
        //        //    model = _data.GetAll(orderBy);
        //        //}
        //        //else
        //        //{
        //        //    model = _data.GetAll();
        //        //}

        //    //    if (model.ToList().Count == 0)
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    return Ok(model);
        //    //}
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }


        //}

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            try
            {
                Model model = _data.GetById(id);
                if (model is not null)
                {
                    return Ok(model);
                }

                return NotFound();
            }
            catch
            {
                throw new ArgumentException("Error the id does not exists");
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Model value)
        {
            try
            {
                Model model = _data.Add(value);
                return Created($"api/[controller]/{model.Id}", model);

            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Model value)
        {
            try
            {
                Model model = _data.Update(id, value);
                if (model is not null)
                {
                    return Ok(model);
                }
                return NotFound();

            }
            catch
            {
                throw new ArgumentException("Could not update");
            }
        }

    }

}