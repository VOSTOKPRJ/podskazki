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
            "Вторая подсказка",
            "Третья подсказка",
        };

        [Description("ID переключателя в меню Server-specific")]
        public int SettingId { get; set; } = 1488;

        [Description("Предупреждение при отключении подсказок")]
        public string Warning { get; set; } = "Если вы не ознакомились с командами, отключая подсказки, вы не сможете апеллировать тем, что не знали, и при нарушении получите наказание.";
    }
}
