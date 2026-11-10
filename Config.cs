using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Podskazki
{
    public class Config : IConfig
    {
        [Description("Включен ли плагин?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Влючен ли режим отладки?")]
        public bool Debug { get; set; } = false;

        [Description("Интервал между подсказками (в секундах)")]
        public float Interval { get; set; } = 300f;

        [Description("Сколько секунд подсказка висит на экране")]
        public float Duration { get; set; } = 10f;

        [Description("Высота подсказки на экране. 0 = самый верх, 1080 = самый низ (вроде как)")]
        public float YCoordinate { get; set; } = 150f;

        [Description("Список подсказок")]
        public List<string> Hints { get; set; } = new List<string>
        {
            "<color=#67CC14><i>Чтобы узнать большинство команд сервера, напишите <b>.help</b> в консоли и зайдите в <b>Server-specific</b> в настройках</i></color>",
            "<color=#67CC14><i><size=45>Возникают лаги при игре на сервере? </size></color>\\n<color=#67CC14><size=35>Попробуйте уменьшить дальность прорисовки маппинга во вкладке server-specific в настройках для увеличения производительности</i></b></color></size>",
            "<size=35><color=#67CC14><i>Со всем кастомным маппингом, таким как крышки вентиляций или двери Дблока можно взаимодействовать на <b>Е</b></i></color></size>",
            "<size=35><color=#67CC14><i>Кастомная музыка слишком громкая? вы можете уменьшить громкость эмбиента <b>в server-specific в настройках</b></color></size>",
            "<size=45><color=#67CC14><i>Кастомные действия</size></color>\\n<size=35><color=#67CC14><i>Кнопки для совершения большинства особых действий, таких как обыск трупа или самотушения можно задать во вкладке <b>server-specific</b> в настройках</color></size>",
            "<size=45><color=#67CC14><i>Возникли вопросы по какой-либо механике?</size></color><color=#67CC14>\n<size=35>Подайте жалобу на администратора с вашим вопросом и он ответит вам в ближайшее время!</color></size>",
            "<size=45><color=#67CC14><i>Система крафтов</color></size>\\n<color=#67CC14><size=35>Большинство ролей могут создавать особые предметы из подручных средств, такие как коктейли Молотова или растяжки. Для того чтобы увидеть перечень доступных к созданию предметов <b>напишите .cr</b> в консоль</color></size>",
            "<size=45><color=#67CC14><i>Прокси-чат</color></size>\\n<color=#67CC14><size=35>SCP-Объекты могут переключатся на чат людей, чтобы их слышали окружающие игроки. Чтобы настроить клавишу для этого, зайдите во вкладку<b> server-specific в настройках</b></color></size>," +
            "<size=45><color=#67CC14><i>Протоколы</color></size>\\n<size=35> <color=#67CC14>Если вы встанете в ЦПУ с картой в руках, вы сможете активировать различные протоколы, такие как блокировка гермоворот и сканирование персонала. Для большей информации напишите<b> .protocol</b> в консоль</color></size>\\n",
        };

        [Description("ID переключателя в меню Server-specific")]
        public int SettingId { get; set; } = 1488;

        [Description("Предупреждение при отключении подсказок")]
        public string Warning { get; set; } = "Если вы не ознакомились с командами, отключая подсказки, вы не сможете апеллировать тем, что не знали, и при нарушении получите наказание.";
    }
}
