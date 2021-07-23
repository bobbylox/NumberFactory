using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceScript : MonoBehaviour
{
    string stepsString;
    public List<MachineLabel> machineSteps;
    public uint limit = 4;
    public CraneMovement crane;

    // Start is called before the first frame update
    void Start()
    {
        stepsString = "";
        machineSteps = new List<MachineLabel>();
    }

    public void AddStep(MachineLabel machine)
    {
        machineSteps.Add(machine);
        stepsString = stepsString + machine.label_text + "   ";
    }

    public bool CheckLimit()
    {
        return machineSteps.Count < limit;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(transform.localPosition.x, transform.localPosition.y, 1000, 50), stepsString);
    }
}
