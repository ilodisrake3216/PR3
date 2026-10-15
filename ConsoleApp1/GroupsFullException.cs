using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GroupsFullException: Exception
    {
        private readonly ILogger<Listener> _logger;
        public GroupsFullException(int rate)
            : base($"Нет свободных мест в группе для балла {rate}") { }
    }
}
