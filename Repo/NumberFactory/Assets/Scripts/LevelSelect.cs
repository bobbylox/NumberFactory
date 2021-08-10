using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelect : MonoBehaviour
{
    public LevelsManager levelsManager = new LevelsManager();
    public void LoadLevels (int levelNumber)
    {
        SceneManager.LoadScene("GameScene");

        string path = "Assets/LevelData/currentLevel.json";
        levelsManager.currentLevel = levelNumber;
        string currentLevelJSON = JsonUtility.ToJson(levelsManager);
        File.WriteAllText(path, currentLevelJSON);
    }
}
