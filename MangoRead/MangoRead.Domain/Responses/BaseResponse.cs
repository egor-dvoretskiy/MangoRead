using MangoRead.Domain.Enums;
using MangoRead.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Descripton { get; set; } = string.Empty;

        public ResponseStatus Status {get; set;}

        public T Data {get; set;}
    }
}
