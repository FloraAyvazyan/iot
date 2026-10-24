using System;
namespace iot.Models

//namespace SmartRoomMonitor.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Remember Me ფუნქციისთვის (არასავალდებულო)
        public bool RememberMe { get; set; } = false;
    }
}