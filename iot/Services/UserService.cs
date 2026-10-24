using System;
using System.Collections.Generic;
using System.Linq;
using SmartRoomMonitor.Models;
using SmartRoomMonitor.Utilities;
using iot.Models;

namespace SmartRoomMonitor.Services
{
    public class UserService
    {
        private readonly JsonStorageService _json;
        private readonly List<User> _users;

        public UserService(JsonStorageService json)
        {
            _json = json;
            _users = _json.ReadList<User>(PathHelper.UsersFile);
        }

        public IReadOnlyList<User> GetAll() => _users;

        public User FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            return _users.FirstOrDefault(u =>
                string.Equals(u.Username, username.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool UsernameExists(string username)
            => FindByUsername(username) != null;

        public void Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (UsernameExists(user.Username))
                throw new InvalidOperationException("მომხმარებელი უკვე არსებობს.");

            _users.Add(user);
            _json.Write(PathHelper.UsersFile, _users);
        }

        public void Update(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing == null) return;

            existing.FullName = user.FullName;
            existing.PasswordHash = user.PasswordHash;
            existing.PasswordSalt = user.PasswordSalt;
            existing.RememberMe = user.RememberMe;

            _json.Write(PathHelper.UsersFile, _users);
        }

        public void Reload()
        {
            var fresh = _json.ReadList<User>(PathHelper.UsersFile);
            _users.Clear();
            _users.AddRange(fresh);
        }
    }
}