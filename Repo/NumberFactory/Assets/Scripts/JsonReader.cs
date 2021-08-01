using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour
{
    [SerializeField]
    public LevelsManager levelsManager;

    void Start()
    {
        string path = "Assets/Levels.json";
        StreamReader reader = new StreamReader(path);
        string levelString = reader.ReadToEnd();
        Debug.Log(levelString);
        //string strResultJson = JsonConvert.SerializeObject(myObject);
        levelsManager = JsonUtility.FromJson<LevelsManager>(levelString);
        Debug.Log(levelsManager.levels);//.number);
    }
}



