using System.IO;
using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad.IO
{
    public class JsonWriterReader : IWriterReader
    {
        public bool IsExist(string path) => File.Exists(path);

        public T Read<T>(string path)
        {
            string json = File.ReadAllText(path);
            T result = JsonUtility.FromJson<T>(json);
            return result;
        }
        
        public void Write(string path, object data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }
}