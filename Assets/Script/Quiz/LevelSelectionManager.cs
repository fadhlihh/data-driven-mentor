using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _levelSelection;
    [SerializeField]
    private GameObject _levelPrefabs;
    [SerializeField]
    private Transform _levelContainer;
    private List<Level> levels = new List<Level>();
    private List<GameObject> _levelPool = new List<GameObject>();

    public void Show()
    {
        UpdateData();
        _levelSelection.gameObject.SetActive(true);
    }

    public void UpdateData()
    {
        levels = GameManager.Instance._levelDataController._listLevel.Levels;
        ClearList();
        foreach (Level level in levels)
        {
            GameObject itemObject = CreateItem(level.Name);
            LevelManager levelManager = itemObject.GetComponent<LevelManager>();
            bool isUnlocked = GameManager.Instance._levelProgressionDataController.CheckUnlockedLevel(level.Name);
            levelManager.BindData(level.Name, isUnlocked, OnSelectLevel);
            _levelPool.Add(itemObject);
        }
    }

    private void ClearList()
    {
        if (_levelPool.Count > 0)
        {
            foreach (GameObject obj in _levelPool)
            {
                Destroy(obj);
            }
            _levelPool.Clear();
        }
    }

    private GameObject CreateItem(int levelName)
    {
        GameObject obj = Instantiate(_levelPrefabs, _levelContainer);
        obj.name = $"Level{levelName}";
        obj.SetActive(true);
        return obj;
    }

    private void OnSelectLevel(int level)
    {
        Debug.Log("Level Selection Click");
        GameManager.Instance._quizManager.Show(level);
        Hide();
    }

    private void Hide()
    {
        _levelSelection.gameObject.SetActive(false);
    }
}
