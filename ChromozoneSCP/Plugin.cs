using Exiled.API.Features;

namespace ChromozoneSCP
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        
        public override string Author => "dhkatz";
        public override string Name => "Chromozone SCP";
        public override string Prefix => "chromozone";

        public override void OnEnabled()
        {
            Instance = this;
            
            RegisterEvents();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            RegisterEvents();
            
            base.OnReloaded();
        }

        private void RegisterEvents()
        {
            Log.Info("Hello World!");
        }
    }
}