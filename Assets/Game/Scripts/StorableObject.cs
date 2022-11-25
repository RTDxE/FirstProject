using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace MergeRace
{
    public class StorableObject : ScriptableObject
    {
        private static string _scriptableObjectsDataDirectory = "ScriptableObjects";

        public Action onLoaded;
        public Action onSaved;
        public Action onChanged;

        public void SaveToFile(string dataName = "")
        {
            if (dataName == "") dataName = name;
#if UNITY_ANDROID || UNITY_IOS
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString($"DATA_{dataName}", json);
#else
            string dirPath = Path.Combine(
                Application.persistentDataPath,
                _scriptableObjectsDataDirectory
            );
            string filePath = Path.Combine(dirPath, $"{dataName}.json");

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            string json = JsonUtility.ToJson(this);
            File.WriteAllText(filePath, json);
#endif
            onSaved?.Invoke();
            Debug.Log($"Saved {dataName}");
        }


        public bool LoadFromFile(string dataName = "")
        {
            if (dataName == "") dataName = name;
#if UNITY_ANDROID || UNITY_IOS
            string json = PlayerPrefs.GetString($"DATA_{dataName}");

            if (string.IsNullOrEmpty(json))
            {
                Debug.Log($"{dataName} not found");
                return false;
            }
#else
            string filePath = Path.Combine(
                Application.persistentDataPath,
                _scriptableObjectsDataDirectory,
                $"{dataName}.json"
            );

            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"File \"{filePath}\" not found! Getting default values.", this);
                return false;
            }

            string json = File.ReadAllText(filePath);
#endif
            JsonUtility.FromJsonOverwrite(json, this);

            onLoaded?.Invoke();
            Debug.Log($"Loaded {dataName}");

            return true;
        }
    }
}