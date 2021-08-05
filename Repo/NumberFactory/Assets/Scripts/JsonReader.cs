using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour
{
    [SerializeField]
    public LevelsObject levelsObject = new LevelsObject();
    public LevelsManager levelsManager = new LevelsManager();
    public MachineManagerScript crane;

    void Start()
    {
        string path = "Assets/currentLevel.json";
        StreamReader reader = new StreamReader(path);
        string levelString = reader.ReadToEnd();
        levelsManager = JsonUtility.FromJson<LevelsManager>(levelString);



        path = "Assets/Level"+levelsManager.currentLevel+".json";
        reader = new StreamReader(path);
        levelString = reader.ReadToEnd();
        levelsObject = JsonUtility.FromJson<LevelsObject>(levelString);
        InitLevel(levelsObject);
    }
    void InitLevel(LevelsObject levelsObject)
    {
        for(int i = 0; i < crane.columns.Length; i++)
        {
            GameObject currentMachine = crane.columns[i];
            MachineLabel currentLabel = currentMachine.GetComponent<MachineLabel>();
            if (!levelsObject.machines.Contains(currentLabel.label_text))
            {
                currentMachine.SetActive(false);
            }
        }
    }
}




