
using System;

namespace Ara3D.Utils
{
    public static class JsonUtil
    {
        public static JsonText ToJson(this object obj)
            => throw new NotImplementedException();
            //=> JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

        public static T FromJson<T>(this JsonText json)
            => throw new NotImplementedException();
        //=> JsonSerializer.Deserialize<T>(json.Value);

        public static JsonText LoadJsonText(this FilePath fp)
            => fp.ReadAllText();

        public static T WriteAsJson<T>(this FilePath fp, T obj)
            => (fp.WriteAllText(obj.ToJson()), obj).Item2;

        public static T LoadObjectAsJsonOrWriteDefault<T>(this FilePath fp) where T : new()
            => fp.LoadObjectAsJsonOrWriteDefault<T>(new T());

        public static T LoadObjectAsJsonOrWriteDefault<T>(this FilePath fp, T deflt)
            => fp?.Exists() == true ? fp.LoadJsonText().FromJson<T>() : deflt;
    }
}
