using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DivisionMachineScript : MonoBehaviour
{

    [SerializeField]
    public MachineScript machine;
    NumberScript number;
   

    public void Divide()
    {
        if(machine.inputs.Count > 0)
        {

            number = machine.inputs[0];
            int newNumber = (int)number.number /2;
            number.transform.DOScale(0f, 0.5f).OnComplete(SwapNumber);
            Debug.Log("Division");

            

        }

         void SwapNumber()
        {
            Debug.Log("DEBUG " + number.number + ", ");
            number.number = (int)number.number / 2;
            number.transform.DOScale(number.GetStartScale(), 0.5f);
        }
    }
}

