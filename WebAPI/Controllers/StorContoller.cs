using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorContoller : ControllerBase
    {
        private IStorService _storservice;
        public StorContoller(IStorService storservice)
        {
            _storservice = storservice;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _storservice.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlistbyadress")]
        public IActionResult GetListByAdress(string stor_address)
        {
            var result = _storservice.GetListByAdress(stor_address);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int stor_id)
        {
            var result = _storservice.GetById(stor_id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Stor stor)
        {
            var result = _storservice.Add(stor);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Stor stor)
        {
            var result = _storservice.Delete(stor);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Stor stor)
        {
            var result = _storservice.Update(stor);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
