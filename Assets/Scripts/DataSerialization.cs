using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSerialization
{
    public static void Serialization(string path, object data)//сохранение данных
    {
        using (FileStream fl = new FileStream(path, FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fl, data);
        }
    }
    public static T Deserialization<T>(string path)//загрузка данных
    {
        using (FileStream fl = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (T)bf.Deserialize(fl);
        }
    }
}
