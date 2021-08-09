using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateMachineScript : MonoBehaviour
{
    public MachineScript machine;
    NumberScript number;
    NumberScript newNumber;
    CraneMovement crane;

    void Start() {
        crane = GameObject.Find("Crane").GetComponent<CraneMovement>();
    }

    public void Duplicate()
    {
        
        number = machine.inputs[0];
        //Debug.Log("Calling Duplicate for " + number.number + " scale: " + number.GetStartScale());
        newNumber = Instantiate(number);
        newNumber.transform.SetParent(crane.transform);
        newNumber.transform.localPosition = new Vector3(0, -0.2f, 0);
        newNumber.transform.localScale = new Vector3(2.11384654f, 2.11384654f, 2.11384654f);
        newNumber.SetStartScale(number.GetStartScale());
        crane.holding = newNumber;
    }
}
