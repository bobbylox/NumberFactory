using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public List<Button> levelButtons;
    public LevelsManager levelsManager;
    public int currentLevel;
    string pathToCurrentLevel = "Assets/LevelData/currentLevel.json";

    void Start()
    {
        StreamReader reader = new StreamReader(pathToCurrentLevel);
        string levelString = reader.ReadToEnd();
        reader.Close();
        levelsManager = JsonUtility.FromJson<LevelsManager>(levelString);
        currentLevel = levelsManager.currentLevel;

        foreach(Button levelButton in levelButtons)
        {
            if (int.Parse(levelButton.gameObject.name) > currentLevel)
            {
                levelButton.interactable = false;
                //devloper mode change false to true.
            }
        }
    }
    public void LoadLevels (int levelNumber)
    {
        SceneManager.LoadScene("GameScene");

        string path = "Assets/LevelData/currentLevel.json";
        levelsManager.currentLevel = levelNumber;
        string currentLevelJSON = JsonUtility.ToJson(levelsManager);
        File.WriteAllText(path, currentLevelJSON);
    }
}
