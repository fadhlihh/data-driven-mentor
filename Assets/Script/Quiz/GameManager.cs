using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public QuizManager _quizManager;
    public LevelSelectionManager _levelSelectionManager;
    public LevelDataController _levelDataController;
    public LevelProgressionDataController _levelProgressionDataController;
}
