using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputMachineScript : MonoBehaviour
{
    [SerializeField]
    public int expecting;
    public MachineScript machine;

    public void EndLevelIfMatch()
    {
        Debug.Log("EndLevelIfMatch function called");
        if(machine.inputs[0].number == expecting)
        {
            Debug.Log("YOU WIN!");
        }
    }
}
