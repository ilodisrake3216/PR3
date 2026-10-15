using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AlreadyexstException:Exception
    {
        private readonly ILogger<Listener> _logger;
        public AlreadyexstException(int groupNumber)
            : base($"Слушатель уже зачислен в группу {groupNumber}") { }
    }
}
