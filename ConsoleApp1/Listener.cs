using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    internal class Listener
    {
        [Key]
        public int id { get; set; }
        public int misses { get; set; }
        [Range(0, 6, ErrorMessage = "В поле должно быть введено целое число от 0 до 6")]
        public int groupnumber { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ]+(?:\s+[a-zA-Zа-яА-ЯёЁ]+){1,2}$",
            ErrorMessage = "В поле должны быть введены буквы и оно должно содержать 3 слова")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string course { get; set; }
        [Range(1, 100, ErrorMessage = "В поле должно быть введено целое число от 1 до 100")]
        public int rate { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Это не почика")]
        public string email { get; set; }

        private readonly ILogger<Listener> _logger;
        public Listener(ILogger<Listener> logger)
        {
            _logger = logger;
        }

        bool group1full = false;
        bool group2full = false;
        bool group3full = false;
        bool group4full = false;
        bool group5full = false;
        bool group6full = false;
        int jelanie = 0;
        public void autopodbor()
        {
            try
            {
                _logger.LogInformation("В каждой группе осталось по одному свободному месту! Запишитесь сейчас! Можете написать желаемый номер группы он будет учтён, когда мест станет больше");
                jelanie = int.Parse(Console.ReadLine());
                if (groupnumber != 0)
                {
                    throw new AlreadyexstException(groupnumber);
                }
                if (rate >= 50)
                {
                    if (rate >= 60)
                    {
                        if (rate >= 70)
                        {
                            if (rate >= 80)
                            {
                                if (rate >= 90)
                                {
                                    if (!group6full)
                                    {
                                        groupnumber = 6;
                                        group6full = true;
                                    }
                                }
                                else
                                    if (!group5full)
                                    {
                                        groupnumber = 5;
                                        group5full = true;
                                    }
                            }
                            else
                                if (!group4full)
                                {
                                    groupnumber = 4;
                                    group4full = true;
                                }
                        }
                        else
                            if (!group3full)
                            {
                                groupnumber = 3;
                                group3full = true;
                            }
                    }
                    else
                        if (!group2full)
                        {
                            groupnumber = 2;
                            group2full = true;
                        }
                }
                else
                    if (!group1full)
                    {
                        groupnumber = 1;
                        group1full = true;
                    }
                if (groupnumber == 0)
                {
                    throw new GroupsFullException(rate);
                }
                _logger.LogInformation(FIO + " был(а) успешно зачислен(а) в группу " + groupnumber);
            }
            catch (AlreadyexstException a)
            {
                _logger.LogWarning(a, "Повторное зачисление, группа {GroupNumber}", groupnumber);
                Console.WriteLine(a.Message);
                Run = false;
            }
            catch (GroupsFullException a)
            {
                _logger.LogWarning(a, "Нет мест для балла {Rate}", rate);
                Console.WriteLine(a.Message + ". Попробуйте позже.");
                Run = false;
            }
            catch (FormatException)
            {
                _logger.LogError("Вы ввели не число");
                _logger.LogWarning("Не удалось зачислить вас в группу, вы будете возвращены к основному жкрану");
                Run = false;
            }
           catch (Exception)
            {
                _logger.LogError("Непредвиденная ошибка");
                _logger.LogWarning("Не удалось зачислить вас в группу, вы будете возвращены к основному жкрану");
                Run = false;
            }
            finally
            {
                if(group1full)
                    _logger.LogInformation("группа 1 - заполнена");
                if (group2full)
                    _logger.LogInformation("группа 2 - заполнена");
                if (group3full)
                    _logger.LogInformation("группа 3 - заполнена");
                if (group4full)
                    _logger.LogInformation("группа 4 - заполнена");
                if (group5full)
                    _logger.LogInformation("группа 5 - заполнена");
                if (group6full)
                    _logger.LogInformation("группа 6 - заполнена");
            }

        }


        public static bool Run
        {
            set;
            get;
        }
    }
}
