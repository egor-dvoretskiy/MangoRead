using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Interfaces
{
    public interface IBaseResponse<T>
    {
        ResponseStatus Status { get; }

        T Data { get; }
    }
}
