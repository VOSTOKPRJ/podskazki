using System;
using Exiled.API.Features;

namespace Podskazki
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Podskazki";
        public override string Author => "Z1her";
        public override Version Version => new Version(6, 7, 0);

        private Handler handler;

        public override void OnEnabled()
        {
            handler = new Handler(this);
            handler.Start();
            base.OnEnabled();

            Log.Info(Name + " v" + Version + " by " + Author + " загружен.");
        }

        public override void OnDisabled()
        {
            handler.Stop();
            handler = null;
            base.OnDisabled();
        }
    }
}
