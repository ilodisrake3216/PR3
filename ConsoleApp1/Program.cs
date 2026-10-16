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
            Listener.Run = true;
            using (ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }))
            {
                ILogger<Listener> logger = loggerFactory.CreateLogger<Listener>();
                Listener obj = new Listener(logger);
     
                while (Listener.Run)
                {
                name:
                    Console.WriteLine("Введите ФИО");
                    string name = Console.ReadLine();
                    if (name == obj.FIO)
                    {
                        logger.LogError("Такой пользователь уже есть, если ваше ФИО и правда совпало и вы не желаете менять логин обратитесь в поддержку");
                        return;
                    }
                    else
                        obj.FIO = name;
                        if (!ValidateField(obj, obj.FIO, nameof(obj.FIO)))
                    {
                        logger.LogWarning("В поле должны быть введены буквы и оно должно cодержать 2 или 3 слова");
                        goto name;
                    }
                group:
                    Console.WriteLine("Введите номер группы. 0 если группы нет");
                    if (int.TryParse(Console.ReadLine(), out int group)) obj.groupnumber = group;
                    else obj.groupnumber = 7;
                    if (!ValidateField(obj, obj.groupnumber, nameof(obj.groupnumber)))
                    {
                        logger.LogWarning("В поле дожно быть введено целое число от 0 до 6");
                        goto group;
                    }
                rate:
                    Console.WriteLine("Введите бал");
                    if (int.TryParse(Console.ReadLine(), out int rateValue)) obj.rate = rateValue;
                    else obj.rate = -1;
                    if (!ValidateField(obj, obj.rate, nameof(obj.rate)))
                    {
                        logger.LogWarning("В поле должно быть введено целое число от 1 до 100");
                        goto rate;
                    }
                    obj.autopodbor();
                    Console.WriteLine();
                    Console.ReadLine();
                    if(Listener.Run)
                    Console.WriteLine("Заврешить? [1] - чтобы завершить");
                    if(Console.ReadLine()=="1")
                    {
                        Listener.Run = false;
                    }
                }
                Console.WriteLine("Заврешение работы");
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
