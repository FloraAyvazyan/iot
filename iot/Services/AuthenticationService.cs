using iot.Models;
using iot.Utilities;
using SmartRoomMonitor.Services;
using System;
using System.Security.Cryptography;

namespace iot.Services
{
    public class AuthenticationService
    {
        private readonly UserService _userService;
        private readonly LoggerService _logger;
        private readonly HistoryService _history;

        // მიმდინარე ავტორიზებული მომხმარებელი
        public User CurrentUser { get; private set; }

        public AuthenticationService(UserService userService, LoggerService logger, HistoryService history)
        {
            _userService = userService;
            _logger = logger;
            _history = history;
        }

        // --- პაროლის ჰეშირება (PBKDF2) ---
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }

        // --- რეგისტრაცია ---
        public bool Register(string fullName, string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage = "სახელი და გვარი სავალდებულოა.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                errorMessage = "მომხმარებლის სახელი სავალდებულოა.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
            {
                errorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 4 სიმბოლოსგან.";
                return false;
            }
            if (_userService.UsernameExists(username))
            {
                errorMessage = "ეს მომხმარებლის სახელი უკვე დაკავებულია.";
                return false;
            }

            try
            {
                string salt = GenerateSalt();
                string hash = HashPassword(password, salt);

                var newUser = new User
                {
                    FullName = fullName.Trim(),
                    Username = username.Trim(),
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    CreatedAt = DateTime.Now
                };

                _userService.Add(newUser);
                _logger.LogInfo($"ახალი მომხმარებელი დარეგისტრირდა: {username}", "Auth", username);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("რეგისტრაციის შეცდომა", ex, "Auth", username);
                errorMessage = "რეგისტრაციის დროს მოხდა შეცდომა: " + ex.Message;
                return false;
            }
        }

        // --- ავტორიზაცია ---
        public bool Login(string username, string password, bool rememberMe, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "შეიყვანე მომხმარებლის სახელი და პაროლი.";
                return false;
            }

            var user = _userService.FindByUsername(username);
            if (user == null)
            {
                errorMessage = "მომხმარებელი ვერ მოიძებნა.";
                _logger.LogWarning($"წარუმატებელი ავტორიზაცია (მომხმარებელი არ არსებობს): {username}", "Auth");
                return false;
            }

            string computedHash = HashPassword(password, user.PasswordSalt);
            if (computedHash != user.PasswordHash)
            {
                errorMessage = "პაროლი არასწორია.";
                _logger.LogWarning($"წარუმატებელი ავტორიზაცია (არასწორი პაროლი): {username}", "Auth");
                return false;
            }

            // წარმატებული ავტორიზაცია
            user.RememberMe = rememberMe;
            _userService.Update(user);
            CurrentUser = user;

            _logger.LogInfo($"მომხმარებელი წარმატებით შევიდა სისტემაში: {username}", "Auth", username);
            _history.Add(HistoryService.EventLogin, $"მომხმარებელი {username} შევიდა სისტემაში", username);

            return true;
        }

        // --- გასვლა ---
        public void Logout()
        {
            if (CurrentUser != null)
            {
                _logger.LogInfo($"მომხმარებელი გავიდა სისტემიდან: {CurrentUser.Username}", "Auth", CurrentUser.Username);
                _history.Add(HistoryService.EventLogout, $"მომხმარებელი {CurrentUser.Username} გავიდა სისტემიდან", CurrentUser.Username);
                CurrentUser = null;
            }
        }
    }
}