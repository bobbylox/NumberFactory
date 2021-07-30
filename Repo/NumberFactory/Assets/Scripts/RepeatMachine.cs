using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RepeatMachine : MonoBehaviour
{
    public MachineScript machine;
    public SequenceScript sequence;
    public CraneMovement crane;
    MachineLabel label;
    int timesToRepeat;


    void Start()
    {
        label = gameObject.GetComponent<MachineLabel>();
    }
    public void Repeat()
    {
        sequence.CloseRepeat(label);
        machine.inputs[0].transform.DOScale(0f, 0.5f).OnComplete(DestroyNumber);
        
    }

    public void DestroyNumber()
    {
        timesToRepeat = (int)machine.inputs[0].number;
        if(timesToRepeat > 1)
        {
            NumberScript repeatNum = machine.inputs[0];
            machine.inputs.Remove(repeatNum);
            Destroy(repeatNum.gameObject);
            timesToRepeat = timesToRepeat - 1;
            Debug.Log("Attempting to Repeat");
            DoAgain();
        }
        else
        {
            NumberScript repeatNum = machine.inputs[0];
            machine.inputs.Remove(repeatNum);
            Destroy(repeatNum.gameObject);
        }
    }

    public void DoAgain()
    {
        
        int sequenceEndPosition = sequence.machineSteps.Count - 2;
        int sequenceStartPosition = sequenceEndPosition;
        while (sequence.machineSteps[sequenceStartPosition].label_text != "[ ]") //until we necounter another repeat machine
        {
            sequenceStartPosition -= 1;
        } //gets the location of the first repeat

        if(sequenceStartPosition == sequenceEndPosition)
        {
            // if there's nothing in-between, do nothing
            return;
        }
        else
        {
            //otherwise start the commands
            sequenceStartPosition += 1;
        }
        //repeat actions until timesToRepeat == 0
        //while (timesToRepeat>0)
        //{
        Debug.Log("Start:"+sequenceStartPosition+" End:"+sequenceEndPosition);
        crane.GoToMachine(sequence.machineSteps[sequenceStartPosition]);
        //}
    }
}
