using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _quiz;
    [SerializeField]
    private Canvas _finishGame;
    [SerializeField]
    private Canvas _wrongAnswer;
    [SerializeField]
    private TMP_Text _level;
    [SerializeField]
    private TMP_Text _question;
    [SerializeField]
    private List<TMP_Text> _options;

    private Level _currentLevel = new Level();

    public void Show(int levelName)
    {
        _quiz.gameObject.SetActive(true);
        UpdateData(levelName);
    }

    public void OnBack()
    {
        Hide();
        GameManager.Instance._levelSelectionManager.Show();
    }

    public void OnRetry()
    {
        HideWrongAnswer();
    }

    public void UpdateData(int levelName)
    {
        _currentLevel = GameManager.Instance._levelDataController.GetLevel(levelName);
        _level.text = $"Level {_currentLevel.Name}";
        _question.text = _currentLevel.Question;
        UpdateOption();
    }

    public void CheckAnswer1()
    {
        if (string.Equals(_options[0].text, _currentLevel.Answer))
        {
            bool isLastLevel = GameManager.Instance._levelDataController.CheckLastLevel(_currentLevel);
            if (isLastLevel)
            {
                ShowFinishGame();
            }
            else
            {
                GameManager.Instance._levelProgressionDataController.AddUnlockedLevel(_currentLevel.Name + 1);
                UpdateData(_currentLevel.Name + 1);
            }
        }
        else
        {
            ShowWrongAnswer();
        }
    }

    public void CheckAnswer2()
    {
        if (string.Equals(_options[1].text, _currentLevel.Answer))
        {
            bool isLastLevel = GameManager.Instance._levelDataController.CheckLastLevel(_currentLevel);
            if (isLastLevel)
            {
                ShowFinishGame();
            }
            else
            {
                GameManager.Instance._levelProgressionDataController.AddUnlockedLevel(_currentLevel.Name + 1);
                UpdateData(_currentLevel.Name + 1);
            }
        }
        else
        {
            ShowWrongAnswer();
        }
    }

    public void CheckAnswer3()
    {
        if (string.Equals(_options[2].text, _currentLevel.Answer))
        {
            bool isLastLevel = GameManager.Instance._levelDataController.CheckLastLevel(_currentLevel);
            if (isLastLevel)
            {
                ShowFinishGame();
            }
            else
            {
                GameManager.Instance._levelProgressionDataController.AddUnlockedLevel(_currentLevel.Name + 1);
                UpdateData(_currentLevel.Name + 1);
            }
        }
        else
        {
            ShowWrongAnswer();
        }
    }

    public void CheckAnswer4()
    {
        if (string.Equals(_options[3].text, _currentLevel.Answer))
        {
            bool isLastLevel = GameManager.Instance._levelDataController.CheckLastLevel(_currentLevel);
            if (isLastLevel)
            {
                ShowFinishGame();
            }
            else
            {
                GameManager.Instance._levelProgressionDataController.AddUnlockedLevel(_currentLevel.Name + 1);
                UpdateData(_currentLevel.Name + 1);
            }
        }
        else
        {
            ShowWrongAnswer();
        }
    }

    private void UpdateOption()
    {
        for (int i = 0; i < _options.Count; i++)
        {
            _options[i].text = _currentLevel.Options[i];
        }
    }

    private void ShowFinishGame()
    {
        _finishGame.gameObject.SetActive(true);
    }

    private void ShowWrongAnswer()
    {
        _wrongAnswer.gameObject.SetActive(true);
    }

    private void HideWrongAnswer()
    {
        _wrongAnswer.gameObject.SetActive(false);
    }

    private void Hide()
    {
        HideWrongAnswer();
        _finishGame.gameObject.SetActive(false);
        _quiz.gameObject.SetActive(false);
    }
}
