using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceScript : MonoBehaviour
{
    string stepsString;
    public List<MachineLabel> machineSteps;
    public uint limit = 99;
    public CraneMovement crane;
    public Camera cam;
    Vector3 screen_coords;

    // Start is called before the first frame update
    void Start()
    {
        stepsString = "";
        machineSteps = new List<MachineLabel>();

        screen_coords = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        screen_coords = cam.WorldToScreenPoint(screen_coords);


    }

    public void AddStep(MachineLabel machine)
    {
        if (machine.label_text == "[ ]")
        {
            machineSteps.Add(machine);
            MachineScript machineScript = machine.gameObject.GetComponent<MachineScript>();
            stepsString = stepsString + crane.holding.number + "[   ";
        }
        else
        {
            machineSteps.Add(machine);
            stepsString = stepsString + machine.label_text + "   ";
        }
    }

    public bool CheckLimit()
    {
        return machineSteps.Count < limit;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(screen_coords.x, screen_coords.y, 1000, 50), stepsString);
    }
}
