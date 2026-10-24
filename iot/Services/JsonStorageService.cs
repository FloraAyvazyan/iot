using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SmartRoomMonitor.Services
{
    public class JsonStorageService
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        private static readonly object FileLock = new object();

        // წაკითხვა — თუ ფაილი არ არსებობს ან ცარიელია, აბრუნებს default მნიშვნელობას
        public T Read<T>(string filePath, T defaultValue)
        {
            lock (FileLock)
            {
                try
                {
                    if (!File.Exists(filePath))
                        return defaultValue;

                    string json = File.ReadAllText(filePath);
                    if (string.IsNullOrWhiteSpace(json))
                        return defaultValue;

                    T result = JsonSerializer.Deserialize<T>(json, JsonOptions);
                    return result == null ? defaultValue : result;
                }
                catch (Exception ex)
                {
                    // კორუმპირებული ფაილი — არ ვაგდებთ exception-ს, ვაბრუნებთ default-ს
                    Console.WriteLine($"JSON read error: {filePath} — {ex.Message}");
                    return defaultValue;
                }
            }
        }

        // ჩაწერა — ცალსახად ვწერთ სუფთად ფორმატირებულ JSON-ს
        public void Write<T>(string filePath, T data)
        {
            lock (FileLock)
            {
                try
                {
                    string dir = Path.GetDirectoryName(filePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    string json = JsonSerializer.Serialize(data, JsonOptions);
                    File.WriteAllText(filePath, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"JSON write error: {filePath} — {ex.Message}");
                    throw;
                }
            }
        }

        // კონკრეტულად სიისთვის დამხმარე მეთოდი
        public List<T> ReadList<T>(string filePath)
        {
            return Read<List<T>>(filePath, new List<T>());
        }
    }
}