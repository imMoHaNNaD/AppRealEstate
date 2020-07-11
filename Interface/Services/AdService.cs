using Application.Advertisement;

using AutoMapper;
using Interface.Message;
using Interface.Model.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Interface.Helper;
using Interface.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Interface.Services
{
    public class AdService
    {

        private readonly IMapper _mapper;
        private AdvertisementApp AdApp = new AdvertisementApp();
        public AdService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BaseResponse<bool> CreateAD(ADCreateModel req)
        {

            var map = _mapper.Map<Advertisement>(req);
            var res = AdApp.Add(map);
            return Helper<bool, bool>.MapToBase(res, _mapper);


        }
        public BaseResponse<bool> RemoveAD(string id)
        {
            var res = AdApp.DeleteByID(id);
            return Helper<bool, bool>.MapToBase(res, _mapper);

        }

        public BaseResponse<List<AdVm>> GetByIDUser([StringLength(24, MinimumLength = 24)] string id)
        {
            var res = AdApp.GetByUserID(id);
            return Helper<IEnumerable<Advertisement>, List<AdVm>>.MapToBase(res, _mapper);

        }
        public BaseResponse<AdVm> GetByID([StringLength(24, MinimumLength = 24)] string id)
        {
            var res = AdApp.GetByID(id);
            return Helper<Advertisement, AdVm>.MapToBase(res, _mapper);
        }

    }
}
