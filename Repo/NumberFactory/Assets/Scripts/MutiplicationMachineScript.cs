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
    public float gravity = -9.81f;
    float velocity;
    public void Mutiplication()
    {
        if (machine.inputs.Count > 1)
        {
            number = machine.inputs[0];
            number2 = machine.inputs[1];
            number1 = (int) number2.number;
           newNumber = (int)number.number * number1;
            number.transform.DOMove(machine.gameObject.transform.position, 0.5f).OnComplete(SwapNumber);
            number2.transform.DOMove(machine.gameObject.transform.position, 0.5f);
            Debug.Log("Multiplication");
        }

       
    }

    void SwapNumber()
    {
        Debug.Log("DEBUG " + number.number + ", ");
        number.number = newNumber;
        number.transform.DOMove(machine.slots[0].position, 0.5f);
        machine.inputs.Remove(number2);
        Destroy(number2.gameObject);
    }
}

