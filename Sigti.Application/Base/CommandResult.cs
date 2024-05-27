using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Base
{
    public class CommandResult:ICommandResult
    {
        public CommandResult(bool success, string message){}
        public CommandResult(List<(bool success,string message)> data){}
    }
}
