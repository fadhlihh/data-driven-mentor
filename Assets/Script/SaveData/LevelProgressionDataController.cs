using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelProgressionDataController : MonoBehaviour
{
    [HideInInspector]
    public LevelProgression _levelProgress = new LevelProgression();


    private string _saveLocation = "/Save/";
    private string _fileName = "levelProgress.sav";

    public bool CheckUnlockedLevel(int level)
    {
        return _levelProgress.UnlockedLevel.Exists(item => item == level);
    }

    public void AddUnlockedLevel(int level)
    {
        _levelProgress.UnlockedLevel.Add(level);
        SaveData();
    }

    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        // Set save directory
        string directory = Application.persistentDataPath + _saveLocation;
        string path = directory + _fileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream dataFile = new FileStream(path, FileMode.Open);
            // Convert from json string to _levelProgress object
            LevelProgression levelProgress = formatter.Deserialize(dataFile) as LevelProgression;
            if (levelProgress != null)
            {
                _levelProgress = levelProgress;
            }
            dataFile.Close();
            Debug.Log(_levelProgress.UnlockedLevel.Count);
            Debug.Log(_levelProgress.UnlockedLevel[0]);
        }
        else
        {
            Directory.CreateDirectory(directory);
            SetInitialData();
        }
    }

    private void SetInitialData()
    {
        _levelProgress.UnlockedLevel.Add(1);
        string textData = JsonUtility.ToJson(_levelProgress);
        SaveData();
    }

    private void SaveData()
    {
        string directory = Application.persistentDataPath + _saveLocation;
        string path = directory + _fileName;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream dataFile = new FileStream(path, FileMode.Create);
        formatter.Serialize(dataFile, _levelProgress);
        dataFile.Close();
    }
}
