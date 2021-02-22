using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Logger.Domain
{
    public enum OperationResultState
    {
        Unknown,
        Succeed,
        Fail,
        Error,
        Warning,
    }
}
