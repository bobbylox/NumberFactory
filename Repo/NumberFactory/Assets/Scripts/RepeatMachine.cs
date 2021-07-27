using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMachine : MonoBehaviour
{
    public MachineScript machine;
    public SequenceScript sequence;
    MachineLabel label;

    void Start()
    {
        label = gameObject.GetComponent<MachineLabel>();
    }
    public void Repeat()
    {
        sequence.CloseRepeat(label);

    }
}
