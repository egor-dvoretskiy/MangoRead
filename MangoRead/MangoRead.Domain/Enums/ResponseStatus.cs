using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Enums
{
    public enum ResponseStatus
    {
        OK = 0,
        EmptyEntity = 101,
        CreateError = 201,
        UpdateError = 301,
        DeleteError = 401,
        InternalServerError = 901,
    }
}
