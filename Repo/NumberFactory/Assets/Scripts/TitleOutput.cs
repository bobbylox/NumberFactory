using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleOutput : MonoBehaviour
{
    [SerializeField]
    public int expecting;
    public MachineScript machine;


    public void EndLevelIfMatch()
    {
        //Debug.Log("EndLevelIfMatch function called");
        if(machine.inputs[0].number == expecting)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
