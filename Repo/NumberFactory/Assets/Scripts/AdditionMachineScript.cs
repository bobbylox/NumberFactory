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
    public float gravity =-9.81f;
    float velocity;

    public void Addition()
    {
        if (machine.inputs.Count > 1)
        {
            number = machine.inputs[0];
            nextNumber = machine.inputs[1];
            number.transform.DOMove(machine.gameObject.transform.position, 0.5f).OnComplete(SwapNumber);
            nextNumber.transform.DOMove(machine.gameObject.transform.position, 0.5f);
            //Debug.Log("Addition");
        }


    }
   
    void SwapNumber()
    {
        //Debug.Log("DEBUG " + number.number + ", " + nextNumber.GetStartScale());
        number.number = nextNumber.number + number.number;
        number.transform.DOMove(machine.slots[0].position, 0.5f);
        machine.inputs.Remove(nextNumber);
        Destroy(nextNumber.gameObject);
    }
}

