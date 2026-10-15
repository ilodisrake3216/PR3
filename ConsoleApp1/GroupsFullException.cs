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
        private readonly ILogger<GroupsFullException> _logger;
        public GroupsFullException(ILogger<GroupsFullException> logger)
        {
            _logger = logger;
        }
        public GroupsFullException()
        {
            _logger.LogError("Кажется все группы заполнены, возвращайтесь позже");
        }
    }
}
