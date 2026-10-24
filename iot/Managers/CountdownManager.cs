using System;

namespace iot.Managers
{
    public class CountdownManager
    {
        private int _totalSeconds;
        private int _remainingSeconds;
        private bool _isActive;

        // ივენთი, რომელიც ეშვება ყოველ წამს (UI-ს განახლებისთვის)
        public event Action<int, int> OnTick;
        // ივენთი, რომელიც ეშვება დროის ამოწურვისას
        public event Action OnFinished;

        public bool IsActive => _isActive;
        public int RemainingSeconds => _remainingSeconds;

        public void StartCountdown(int seconds)
        {
            _totalSeconds = seconds;
            _remainingSeconds = seconds;
            _isActive = true;

            // თავიდანვე ვაგზავნით სიგნალს, რომ ProgressBar-მა იცოდეს საწყისი მდგომარეობა
            OnTick?.Invoke(_remainingSeconds, _totalSeconds);
        }

        public void ResetCountdown()
        {
            _remainingSeconds = _totalSeconds;
            _isActive = true;
            OnTick?.Invoke(_remainingSeconds, _totalSeconds);
        }

        public void StopCountdown()
        {
            _isActive = false;
            _remainingSeconds = 0;
        }

        // ამ მეთოდს გამოვიძახებთ ტაიმერიდან ყოველ წამს
        public void Update()
        {
            if (!_isActive) return;

            _remainingSeconds--;
            OnTick?.Invoke(_remainingSeconds, _totalSeconds);

            if (_remainingSeconds <= 0)
            {
                _isActive = false;
                OnFinished?.Invoke();
            }
        }
    }
}