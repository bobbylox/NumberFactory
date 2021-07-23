using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MutiplicationMachineScript : MonoBehaviour
{

    [SerializeField]
    public MachineScript machine;
    NumberScript number;
    NumberScript number2;
    int number1;
    int newNumber;
    public void Mutiplication()
    {
        if (machine.inputs.Count > 1)
        {
            number = machine.inputs[0];
            number2 = machine.inputs[1];
            number1 = (int) number2.number;
           newNumber = (int)number.number * number1;
            number.transform.DOScale(0f, 0.5f).OnComplete(SwapNumber);
            number2.transform.DOScale(0f, 0.5f);
            Debug.Log("Multiplication");
        }

       
    }

    void SwapNumber()
    {
        Debug.Log("DEBUG " + number.number + ", ");
        number.number = newNumber;
        number.transform.DOScale(number.GetStartScale(), 0.5f);
        machine.inputs.Remove(number2);
        Destroy(number2.gameObject);
    }
}

