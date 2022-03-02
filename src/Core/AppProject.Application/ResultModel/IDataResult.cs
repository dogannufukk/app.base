using System;
using System.Collections.Generic;
using System.Text;

namespace AppProject.Application.ResultModel
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
