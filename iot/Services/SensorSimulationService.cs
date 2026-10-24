using System;

namespace iot.Services
{
    public class SensorSimulationService
    {
        // ოთახის სტატუსი: true = ადამიანია, false = ცარიელია
        public bool IsPersonDetected { get; private set; }
        public DateTime? LastDetectionTime { get; private set; }

        public SensorSimulationService()
        {
            IsPersonDetected = false;
            LastDetectionTime = null;
        }

        // ადამიანის აღმოჩენის სიმულაცია
        public void DetectPerson()
        {
            IsPersonDetected = true;
            LastDetectionTime = DateTime.Now;
        }

        // ადამიანის წასვლის სიმულაცია
        public void NoPersonDetected()
        {
            IsPersonDetected = false;
        }

        // შემთხვევითი სიმულაცია (თუ მოგვიანებით დაგჭირდა)
        public bool RandomSimulation()
        {
            var rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                DetectPerson();
                return true;
            }
            else
            {
                NoPersonDetected();
                return false;
            }
        }
    }
}