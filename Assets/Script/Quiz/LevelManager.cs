using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public bool IsUnlock;
    public UnityAction<int> OnSelectLevel;

    [SerializeField]
    private TMP_Text _levelText;

    public void BindData(int level, bool isUnlock, UnityAction<int> onSelectLevel)
    {
        Level = level;
        IsUnlock = isUnlock;
        OnSelectLevel = onSelectLevel;
        UpdateView();
    }

    public void UpdateView()
    {
        _levelText.text = Level.ToString();
        GetComponent<Button>().interactable = IsUnlock;
    }

    private void Awake()
    {
        SetCallbacks();
    }

    private void SetCallbacks()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClickLevel);
    }

    private void OnClickLevel()
    {
        Debug.Log("Level Item Click");
        OnSelectLevel(Level);
    }
}
