using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using HintServiceMeow.Core.Enum;
using HintServiceMeow.Core.Utilities;
using MEC;
using Hint = HintServiceMeow.Core.Models.Hints.Hint;

namespace Podskazki
{
    public class Handler
    {
        private readonly Plugin _plugin;
        private readonly List<SettingBase> _settings = new List<SettingBase>();
        private CoroutineHandle _coroutine;
        private int _index;

        public Handler(Plugin plugin)
        {
            _plugin = plugin;
        }

        public void Start()
        {
            _settings.Add(new HeaderSetting(_plugin.Config.SettingId - 1, "Подсказки", _plugin.Config.Warning));
            _settings.Add(new TwoButtonsSetting(_plugin.Config.SettingId, "Подсказки", "Включены", "Выключены",
                false, _plugin.Config.Warning, 255, false, null, OnToggleChanged));

            SettingBase.Register(_settings);
            _coroutine = Timing.RunCoroutine(HintLoop());
        }

        public void Stop()
        {
            Timing.KillCoroutines(_coroutine);
            SettingBase.Unregister(player => true, _settings);
            _settings.Clear();
        }

        private IEnumerator<float> HintLoop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(_plugin.Config.Interval);

                var hints = _plugin.Config.Hints;
                if (hints.Count == 0)
                    continue;

                if (_index >= hints.Count)
                    _index = 0;

                var text = hints[_index];
                _index++;

                foreach (var player in Player.List)
                {
                    if (!IsDisabled(player))
                        Timing.RunCoroutine(ShowHint(player, text, _plugin.Config.Duration));
                }
            }
        }
        // Вы нашли пасхалко! Хлопните в ладоши если у вас есть родители.
        private IEnumerator<float> ShowHint(Player player, string text, float duration)
        {
            var hint = new Hint
            {
                Text = text,
                YCoordinate = _plugin.Config.YCoordinate,
                Alignment = HintAlignment.Center,
                FontSize = 24
            };

            var display = PlayerDisplay.Get(player);
            display.AddHint(hint);

            yield return Timing.WaitForSeconds(duration);

            display.RemoveHint(hint);
        }

        private bool IsDisabled(Player player)
        {
            return SettingBase.TryGetSetting(player, _plugin.Config.SettingId, out TwoButtonsSetting setting)
                   && setting.IsSecond;
        }

        private void OnToggleChanged(Player player, SettingBase setting)
        {
            var toggle = (TwoButtonsSetting)setting;

            if (toggle.IsSecond)
                Timing.RunCoroutine(ShowHint(player, "<color=red>Внимание!</color> " + _plugin.Config.Warning, 15f));
        }
    }
}
