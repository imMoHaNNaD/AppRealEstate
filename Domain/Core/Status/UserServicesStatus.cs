using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Status
{
    public enum  UserServicesStatus
    {
        OK = 200,
        Cancelled = 1,
        UnknownError = 2,
        Unauthenticated = 3,
        Unauthorized = 4,
        ServicesFailed = 5,
        ValidationFailed = 6,
        WrongUserNameOrPassword = 7,
        NotFoundUser = 8,
        EmailExisting = 9,
        TokenIsinvalid =10

    }
}
