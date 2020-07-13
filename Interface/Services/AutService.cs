using Application.User;
using AutoMapper;
using Domain.Repository.Application;
using Interface.Helper;
using Interface.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Services
{
    public class AutService
    {
        private readonly IMapper _mapper;
        IAutApp _Service;
        public AutService(IMapper mapper)
        {
            _mapper = mapper;
            _Service = new UserApp();
        }

        public BaseResponse<string> Login(string user,string password)
        {
           var res= _Service.Login(user,password);
            return Helper<string, string>.MapToBase(res, _mapper);

        }

        public BaseResponse<bool> ValadtionToken(string Token)
        {
            var res = _Service.ValadtionToken(Token);
            return Helper<bool, bool>.MapToBase(res, _mapper);

        }
    }
}
