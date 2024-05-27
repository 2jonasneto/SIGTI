using Flunt.Notifications;
using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Base
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {

        }
        public GenericCommandResult(bool success, string message, IReadOnlyCollection<Notification> data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public GenericCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Data { get; set; }
    }
}
