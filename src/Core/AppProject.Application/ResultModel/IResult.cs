using System;
using System.Collections.Generic;
using System.Text;

namespace AppProject.Application.ResultModel
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
