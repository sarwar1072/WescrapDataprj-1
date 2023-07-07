using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VillaWebApi.Data;
using VillaWebApi.Model;

namespace VillaWebApi.Controllers
{
    [Route("api/Villa")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]

        public ActionResult<IEnumerable<Villa>> GetVillas()
        {
            return Ok(DataStore.listVilla);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Villa> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();    
            }
            var villa = DataStore.listVilla.FirstOrDefault(x => x.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

    }
}
