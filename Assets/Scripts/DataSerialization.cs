using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSerialization
{
    public static void Serialization(string path, object data)//���������� ������
    {
        using (FileStream fl = new FileStream(path, FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fl, data);
        }
    }
    public static T Deserialization<T>(string path)//�������� ������
    {
        using (FileStream fl = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (T)bf.Deserialize(fl);
        }
    }
}
