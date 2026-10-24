using System;

namespace iot.Services
{
    public class LightController
    {
        // შუქის სტატუსი: true = ჩართულია, false = გამორთულია
        public bool IsLightOn { get; private set; }

        public LightController()
        {
            IsLightOn = false;
        }

        public void TurnOnLight()
        {
            IsLightOn = true;
        }

        public void TurnOffLight()
        {
            IsLightOn = false;
        }

        public void ToggleLight()
        {
            IsLightOn = !IsLightOn;
        }
    }
}