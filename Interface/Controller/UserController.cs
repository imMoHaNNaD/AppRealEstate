using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Interface.Message;
using Interface.Model;
using Interface.Model.User;
using Interface.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interface
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        private readonly IMapper _mapper;
        //public UserService() { }
        public UserController(IMapper mapper)
        {
            _service = new UserService(mapper);
            _mapper = mapper;
        }
        //UserController(UserService service) {
        //    _service = service;
        //}
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public BaseResponse<bool> Post(UserCreateModel req)
        {
           return _service.CreateUser(req);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public void Put([Bind("uu")]Test test)
        {
            if (!ModelState.IsValid) {
                var T=1;
               var res = ModelState.Keys.ToArr();
                var m = ModelState.Values.Select(e=>e.Errors.Select(em=>em.ErrorMessage)).Select(c=>c);
              
                Console.WriteLine(res);
                Console.WriteLine(m);

            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete([StringLength(24, MinimumLength = 24)] string id)
        {
            return _service.RemoveUser(id);

        }
        [HttpGet("{id}")]
        public BaseResponse<UserVm> Get([StringLength(24, MinimumLength = 24)] string id)
        {
            return _service.GetByIDUser(id);

        }

        [HttpGet]
        public BaseResponse<List<UserVm>> Get()
        {
            return _service.GetUser();

        }


    }
}
