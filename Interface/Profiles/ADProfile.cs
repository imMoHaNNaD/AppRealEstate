using AutoMapper;
using Domain.Entity;
using Interface.Model.AD;
using Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Profiles
{
  
        public class ADProfile : Profile
        {
            public ADProfile()
            {
                CreateMap<ADCreateModel, Advertisement>();
                CreateMap<Advertisement, AdVm>();


            }
        }
    }