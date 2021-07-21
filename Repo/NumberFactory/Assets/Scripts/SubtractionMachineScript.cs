using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionMachineScript : MonoBehaviour
{

    [SerializeField]
    public MachineScript machine;
    public NumberScript Number;


    public void Subtraction()
    {
        if (machine.inputs.Count > 0)
        {

           Mathf.Floor(Number.number - 5);

            Debug.Log("subtraction");

        }
    }
    }