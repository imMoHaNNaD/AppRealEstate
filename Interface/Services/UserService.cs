using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.User;
using AutoMapper;
using Domain.Entity;
using Interface.Message;
using Interface.Model.User;
using Interface.Helper;
using Interface.ViewModel.User;

namespace Interface
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private UserApp userApp = new UserApp();
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

       public BaseResponse<bool> CreateUser(UserCreateModel req) {

          var map = _mapper.Map<User>(req);
          var res=  userApp.CreateUser(map);
            return Helper<bool, bool>.MapToBase(res, _mapper);


        }
        public BaseResponse<bool> RemoveUser(string id) 
        {
            var res = userApp.DeleteUser(id);
            return Helper<bool, bool>.MapToBase(res, _mapper);

        }

        public BaseResponse<UserVm> GetByIDUser(string id) {
            var res = userApp.GetByIDUser(id);
            return Helper<User, UserVm>.MapToBase(res, _mapper);

        }
        public BaseResponse<List<UserVm>> GetUser()
        {
            var res = userApp.GetUser();
            return Helper<List<User>, List<UserVm>>.MapToBase(res, _mapper);
        }
    }
}
