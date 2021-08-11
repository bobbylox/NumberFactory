using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public void BackButton(string sceneName)
    {
        LastScene.lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToLastScene()
    {
        SceneManager.LoadScene(LastScene.lastScene);
    }
}

public static class LastScene
{
    public static string lastScene;
}