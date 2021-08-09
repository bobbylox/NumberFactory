using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResetData : MonoBehaviour
{
    [SerializeField]
    public LevelsManager levelsManager = new LevelsManager();
    public void ResetDataIfClicked()
    {
        string path = "Assets/LevelData/currentLevel.json";

        levelsManager.currentLevel = 0;
        string currentLevelJSON = JsonUtility.ToJson(levelsManager);
        File.WriteAllText(path, currentLevelJSON);
    }
}
