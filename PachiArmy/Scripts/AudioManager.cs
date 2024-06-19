using Microsoft.JSInterop;

namespace CatiArmi.Scripts
{
    public static class AudioManager
    {
        private static IJSRuntime JS;
        public static void InitializeJSRuntime(IJSRuntime js)
        {
            JS = js;
        }

        public static void PlayMusic()
        {
            Task.Run(async () => await JS.InvokeVoidAsync("playMusic"));
        }

        public static void PlaySound(string sound)
        {
            Task.Run(async () => await JS.InvokeVoidAsync("playSound", sound));
        }
    }
}
