using IPA;

namespace IgnoreCinema
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }

        [Init]
        public void Init()
        {
            Instance = this;
            SongCore.Collections.RegisterCapability("Cinema");
        }
    }
}
