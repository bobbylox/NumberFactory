using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionMachineScript : MonoBehaviour
{

    [SerializeField]
    public MachineScript machine;
    public NumberScript Number;
    public Transform NumberTemplate;

    public void Divide()
    {
        if(machine.inputs.Count > 0)
        {
         //   Instantiate(NumberTemplate, new Vector3((transform.position.x, -transform.position.y, transform.position.z)));
            Number = machine.inputs[0];
            Mathf.Floor(Number.number / 2);

            Debug.Log("Divide");

        }

    }
}
