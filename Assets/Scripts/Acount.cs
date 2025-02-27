using System;
using System.IO;
using UnityEngine;

public class Acount : MonoBehaviour
{
    public static Action<LocalData> OnChangeData;
    public static Acount Instance;
    [SerializeField] private string dataFile;
    [SerializeField] private string dataPath;
    [SerializeField] private LocalData localData;
    public LocalData LocalData 
    {
        get
        {
            return localData;
        }
        set
        {
            localData = value;
            OnChangeData?.Invoke(localData);//реализация паттерна проектировния - Observer
            DataSerialization.Serialization(dataPath, value);
        }
    }
    public string PlayerName;
    private void Awake()
    {
        //реализация паттерна проектирования - Singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        LoadData();
    }
    public void LoadData()
    {
        dataPath = Path.Combine(Application.dataPath, dataFile);
        if (File.Exists(dataPath))
        {
            LocalData = DataSerialization.Deserialization<LocalData>(dataPath);
        }
        else
            DataSerialization.Serialization(dataPath, LocalData);
    }
}
