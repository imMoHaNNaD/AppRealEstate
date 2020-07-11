using AutoMapper;
using Domain.Core.Status;
using Interface.Message;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Helper
{
    static public class Helper <T,D>
    {
        static public BaseResponse<D> MapToBase(Either<UserServicesStatus, T> eithers , IMapper map) {

            return eithers.Match(
              Left: l =>
              new BaseResponse<D>
              {
                  status = new Status
                  {
                      statusCode = "",
                      statusMessage = l.ToString()
                  },

              }
             ,
              Right: r => new BaseResponse<D>
              {
                  status = new Status
                  {
                      statusCode = "200",
                      statusMessage = "Ok"
                  },
                  body = map.Map<D>(r)
              }
              ); ; ;


        }

    }
}
