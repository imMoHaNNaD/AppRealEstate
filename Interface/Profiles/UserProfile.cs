using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Interface.Model.User;
using Interface.ViewModel.User;

namespace Interface.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateModel, User>();
            CreateMap<User, UserVm>();
            CreateMap<UserVm, User>();



        }
    }
}
