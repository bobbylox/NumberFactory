using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    [SerializeField]
    public List<Transform> slots;
    public List<NumberScript> inputs;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Transform>();
        inputs = new List<NumberScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform CanInsert()
    {
        if(inputs.Count < slots.Count)
        {
            return slots[inputs.Count];
        }
        else
        {
            return null;
        }
    }

    public void Insert(NumberScript num)
    {
        inputs.Add(num);
        if(inputs.Count == slots.Count)
        {
            //Do the thing
        }
    }
}
