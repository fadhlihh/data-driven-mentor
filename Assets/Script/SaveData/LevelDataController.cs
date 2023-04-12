using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataController : MonoBehaviour
{
    [HideInInspector]
    public ListLevel _listLevel = new ListLevel();
    [SerializeField]
    private TextAsset _levelFile;

    public Level GetLevel(int levelName)
    {
        return _listLevel.Levels.Find(item => item.Name == levelName);
    }

    public bool CheckLastLevel(Level level)
    {
        Debug.Log("Index: " + _listLevel.Levels.IndexOf(level));
        Debug.Log("Count: " + _listLevel.Levels.Count);
        return _listLevel.Levels.IndexOf(level) >= _listLevel.Levels.Count - 1;
    }

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        GameManager.Instance._levelSelectionManager.Show();
    }

    private void LoadData()
    {
        _listLevel = JsonUtility.FromJson<ListLevel>(_levelFile.text);
        Debug.Log("Level: " + _listLevel.Levels[0].Name);
        Debug.Log("Question: " + _listLevel.Levels[0].Question);
        Debug.Log("A: " + _listLevel.Levels[0].Options[0]);
        Debug.Log("B: " + _listLevel.Levels[0].Options[1]);
        Debug.Log("C: " + _listLevel.Levels[0].Options[2]);
        Debug.Log("D: " + _listLevel.Levels[0].Options[3]);
        Debug.Log("Answer: " + _listLevel.Levels[0].Answer);
        Debug.Log("Duration: " + _listLevel.Levels[0].Duration);
    }
}
