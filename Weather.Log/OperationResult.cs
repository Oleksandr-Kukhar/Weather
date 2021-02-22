using System;
using System.Collections.Generic;
using System.Text;
using Weather.Logger.Domain;

namespace Weather.Logger
{
    public class OperationResult
    {
        public string Message { get; protected set; }
        public OperationResultState ResultState { get; protected set; }

        public OperationResult()
        {
            Message = string.Empty;
            ResultState = OperationResultState.Unknown;
        }

        public OperationResult(string message, OperationResultState resultState)
        {
            Message = message;
            ResultState = resultState;
        }

        public static OperationResult GeOperationtResult(OperationResultState resultState, string message = "")
        {
            return new OperationResult(message, resultState);
        }
    }
}
