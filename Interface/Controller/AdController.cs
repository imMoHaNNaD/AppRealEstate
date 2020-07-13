using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Interface.Message;
using Interface.Model.AD;
using Interface.Services;
using Interface.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interface.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdController : ControllerBase
    {
        private readonly AdService _service;

        private readonly IMapper _mapper;
        public AdController(IMapper mapper)
        {
            _service = new AdService(mapper);
            _mapper = mapper;
        }

       

        // GET api/<AdController>/5
        [HttpGet("GetByUser")]
        public BaseResponse<List<AdVm>> GetByUser(string id)
        {
            return    _service.GetByIDUser(id);


        }

        // POST api/<AdController>
        [HttpPost]
        public BaseResponse<bool> Post(ADCreateModel value)
        {
          return _service.CreateAD(value);
        }

        //// PUT api/<AdController>/5
        //[HttpPut("GetByID")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpPut("GetByID")]
        public BaseResponse<AdVm> Get(string id)
        {
            return _service.GetByID(id);

        }

        // DELETE api/<AdController>/5
        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete(string id)
        {
            return _service.RemoveAD(id);

        }
    }
}
