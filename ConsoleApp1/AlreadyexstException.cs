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
        private readonly ILogger<AlreadyexstException> _logger;
        public AlreadyexstException(ILogger<AlreadyexstException> logger)
        {
            _logger = logger;
        }
        public AlreadyexstException()
        {
            _logger.LogError("Вы уже зачислены в одну группу");
        }
    }
}
