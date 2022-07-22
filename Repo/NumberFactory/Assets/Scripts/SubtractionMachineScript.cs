using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubtractionMachineScript : MonoBehaviour
{

    [SerializeField]
    public MachineScript machine;
    NumberScript number;

    public void Subtraction()
    {
        if (machine.inputs.Count > 0)
        {
            number = machine.inputs[0];
            int newNumber = (int)-number.number;
            number.transform.DOMove(machine.gameObject.transform.position, 0.5f).OnComplete(SwapNumber);
            Debug.Log("subtraction");
        }
    }

    public void SwapNumber()
    {
        Debug.Log("DEBUG "+number.number + ", ");
        number.number = (int)-number.number;
        number.transform.DOMove(machine.slots[0].position, 0.5f);
    }
}