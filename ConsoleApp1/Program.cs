using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }))
            {
                ILogger<Listener> logger = loggerFactory.CreateLogger<Listener>();
                Listener obj = new Listener(logger);
                Console.WriteLine("Введите ФИО");
                obj.FIO = Console.ReadLine();
                if (!ValidateField(obj, obj.FIO, nameof(obj.FIO)))
                {
                    Console.WriteLine("В поле должны быть введены буквы и оно должно одержать 3 слова");
                }
                Console.WriteLine("Введите номер группы. 0 если группы нет");
                if (int.TryParse(Console.ReadLine(), out int group)) obj.groupnumber = group;
                else obj.groupnumber = -1;
                if (!ValidateField(obj, obj.groupnumber, nameof(obj.groupnumber)))
                {
                    Console.WriteLine("В поле дожно быть введено целое число от 0 до 6");
                }
                Console.WriteLine("Введите бал");
                if (int.TryParse(Console.ReadLine(), out int rateValue)) obj.rate = rateValue;
                else obj.rate = -1;
                if (!ValidateField(obj, obj.rate, nameof(obj.rate)))
                {
                    Console.WriteLine("В поле должно быть введено целое число от 1 до 100");
                }
                obj.autopodbor();
                Console.WriteLine("Добавим еще одного студента");
                Console.WriteLine("Введите ФИО");
                obj.FIO = Console.ReadLine();
                if (!ValidateField(obj, obj.FIO, nameof(obj.FIO)))
                {
                    Console.WriteLine("В поле должны быть введены буквы и оно должно одержать 3 слова");
                }
                Console.WriteLine("Введите номер группы. 0 если группы нет");
                if (int.TryParse(Console.ReadLine(), out int group2)) obj.groupnumber = group2;
                else obj.groupnumber = -1;
                if (!ValidateField(obj, obj.groupnumber, nameof(obj.groupnumber)))
                {
                    Console.WriteLine("В поле дожно быть введено целое число от 0 до 6");
                }
                Console.WriteLine("Введите бал");
                if (int.TryParse(Console.ReadLine(), out int rateValue2)) obj.rate = rateValue2;
                else obj.rate = -1;
                if (!ValidateField(obj, obj.rate, nameof(obj.rate)))
                {
                    Console.WriteLine("В поле должно быть введено целое число от 1 до 100");
                }
                obj.autopodbor();
            }
        }
        static bool ValidateField(object model, object value, string propertyName)
        {
            var context = new ValidationContext(model) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            return Validator.TryValidateProperty(value, context, results);
        }
    }
}