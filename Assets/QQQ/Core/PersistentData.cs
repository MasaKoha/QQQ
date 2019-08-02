using System;
using System.IO;
using UnityEngine;

namespace QQQ.Core
{
    public static class PersistentData
    {
        private static readonly string PersistentDataPath = $"{Application.persistentDataPath}/";

        private static IEncoder _encoder;

        private static IDecoder _decoder;

        static PersistentData()
        {
            _encoder = new Base64Encoder();
            _decoder = new Base64Decoder();
        }

        public static void SaveToJson<TClass>(TClass param) where TClass : class
        {
            var type = param.GetType().Name;
            var json = JsonUtility.ToJson(param);
            Save(json, type);
        }

        public static TClass LoadFromJson<TClass>() where TClass : class
        {
            var line = Load(typeof(TClass).Name);
            return JsonUtility.FromJson<TClass>(line);
        }

        private static void Save(string param, string className)
        {
            var path = PersistentDataPath + className + ".json";
            var encodeParam = _encoder.Encode(param);
            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(encodeParam);
            }
        }

        private static string Load(string className)
        {
            string line = "";
            var path = PersistentDataPath + className + ".json";

            if (!System.IO.File.Exists(path))
            {
                return "";
            }

            StreamReader sr = null;

            try
            {
                sr = new StreamReader(path);
            }
            catch (Exception)
            {
                Debug.Log($"{className}.json not found.");
                sr.Close();
                return "";
            }

            line = sr.ReadLine();
            sr.Close();
            var decodeParam = _decoder.Decode(line);
            return decodeParam;
        }

        public static void Delete<TClass>() where TClass : class
        {
            var deleteFile = PersistentDataPath + typeof(TClass).Name + ".json";
            File.Delete(deleteFile);
        }
    }
}