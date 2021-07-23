using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AdditionMachineScript : MonoBehaviour

{

    [SerializeField]
    public MachineScript machine;
    NumberScript number;
    NumberScript nextNumber;

    public void Addition()
    {
        if (machine.inputs.Count > 1)
        {
            number = machine.inputs[0];
            nextNumber = machine.inputs[1];
            number.transform.DOScale(0f, 0.5f).OnComplete(SwapNumber);
            nextNumber.transform.DOScale(0f, 0.5f);
            Debug.Log("Addition");
        }


    }

    void SwapNumber()
    {
        Debug.Log("DEBUG " + number.number + ", ");
        number.number = nextNumber.number + number.number;
        number.transform.DOScale(number.GetStartScale(), 0.5f);
        machine.inputs.Remove(nextNumber);
        Destroy(nextNumber.gameObject);
    }
}

