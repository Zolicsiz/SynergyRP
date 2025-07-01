using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP
{
    public class Config : IConfig
    {
        public bool IsEnabled { get ; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Название схематика для SCP 173")]
        public string Schematic173 { get; set; } = "here";
        [Description("Имена для ученых")]
        public List<string> ScientistsNames { get; set; } = new List<string>()
        {
            "Иван Топоров",
            "Александр Топоров",
            "Роман Чкалов",
            "Василий Клевещев",
            "Максим Громов",
            "Савелий Ткачёв",
            "Артем Коробейников",
            "Сергей Иванов",
            "Алексей Дубов",
            "Алексей Смирнов",
            "Даниил Покров",
            "Никита Голубев",
            "Кирилл Васнецов",
            "Олег Круглов",
            "Андрей Жданов",
            "Дмитрий Лесников",
            "Борис Левин",
            "Василий Новиков",
            "Владимир Жуков",
            "Тимофей Никольцев",
            "Руслан Ахмедов",
            "Антон Абдонов",
            "Валерий Морозов",
            "Виктор Бобов",
        };
        [Description("Имена для охраны")]
        public List<string> GuardsNames { get; set; } = new List<string>()
        {
            "Шторм",
            "Гром",
            "Град",
            "Бревно",
            "Полено",
            "Постебайло",
            "Кабан",
            "Муха",
            "Волк",
            "Пугач",
            "Око",
            "Аккорд",
            "Призрак",
            "Сова",
            "Пуля",
            "Скат",
            "Кирпич",
        };
        [Description("Имена для MTF")]
        public List<string> MTFNames { get; set; } = new List<string>()
        {
            "Тайфун",
            "Цунами",
            "Мгла",
            "Тайга",
            "Сайга",
            "Молот",
            "Череп",
            "Лир",
            "Беркут",
            "Орёл",
            "Жук",
            "Алмаз",
            "Якут",
            "Болтун",
            "Ворон",
            "Коршун",
            "Воробей",
            "Весна",
            "Пионер",
            "Скаут",
            "Крик",

        };
        [Description("Имена для Chaos")]
        public List<string> CHNames { get; set; } = new List<string>()
        {
            "Кувалда",
            "Тагилла",
            "Амур",
            "Герой",
            "Решала",
            "Санитар",
            "Потрошитель",
            "Отступник",
            "Егерь",
            "Скупщик",
            "Картер",
            "Лыжник",
            "Алтын",
            "Якорь",
            "Осень",
            "Занавес",
            "Бисмарк",
            "Тигр",
            "Дикий",
            "Зверь",
            "Затвор",
            "Рыхлый",
            "Храм",
            "Тамада",
            "Птаха",
            "Альтаир",
            "Калий",
            "Хром",
            "Бром",

        };

        [Description("Cinfo для Научного персонала")]
        public List<string> SCCinfo { get; set; } = new List<string>()
        {
            "<color=#00FFFF>| Старший Исследователь |</color>",
            "<color=#00FFFF>| Инженер Камер Содержания |</color>",
            "<color=#00FFFF>| Штатный Медик |</color>",
            "<color=#00FFFF>| Рядовой Исследователь |</color>",
            "<color=#00FFFF>| Лаборант |</color>",
        };
        
    }
}
