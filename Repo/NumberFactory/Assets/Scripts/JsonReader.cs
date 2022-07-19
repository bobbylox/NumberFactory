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
    public OutputMachineScript output;
    public MachineScript input;
    public SequenceScript sequence;

    string pathToCurrentLevel = "Assets/LevelData/currentLevel.json";

    void Start()
    {
        string path = pathToCurrentLevel;
        StreamReader reader = new StreamReader(path);
        string levelString = reader.ReadToEnd();
        if (levelString == "")
        {
            levelString = "{'currentLevel':0}";
        }
        reader.Close();
        levelsManager = JsonUtility.FromJson<LevelsManager>(levelString);
        path = "Assets/LevelData/Level"+levelsManager.currentLevel+".json";
        reader = new StreamReader(path);
        levelString = reader.ReadToEnd();
        reader.Close();
        levelsObject = JsonUtility.FromJson<LevelsObject>(levelString);
        InitLevel(levelsObject);
    }
    void InitLevel(LevelsObject levelsObject)
    {
        // Initializing active machines
        for(int i = 0; i < crane.columns.Length; i++)
        {
            GameObject currentMachine = crane.columns[i];
            MachineLabel currentLabel = currentMachine.GetComponent<MachineLabel>();
            if (!levelsObject.machines.Contains(currentLabel.label_text))
            {
                currentMachine.SetActive(false);
            }
        }
        //Initialize output
        output.expecting = levelsObject.output;

        //Inputs
        if(levelsObject.inputs.Count > 1)
        {
            input.inputs[0].number = levelsObject.inputs[0];
            input.inputs[1].number = levelsObject.inputs[1];
        }
        else if(levelsObject.inputs.Count == 1)
        {
            input.inputs[0].number = levelsObject.inputs[0];

            NumberScript numToRemove = input.inputs[1];
            input.inputs.Remove(numToRemove);
            Destroy(numToRemove.gameObject);
        }
        else
        {
            //throw error
        }

        //Sequence Limit
        sequence.limit = (uint)levelsObject.sequenceLimit;
    }

    public void SetCurrentLevel(uint newCurrentLevel)
    {
        levelsManager.currentLevel = (int)newCurrentLevel;

        string currentLevelJSON = JsonUtility.ToJson(levelsManager);
        File.WriteAllText(pathToCurrentLevel,currentLevelJSON);
    }

    public void IncrementCurrentLevel()
    {
        SetCurrentLevel((uint)levelsManager.currentLevel + 1);
    }
}




