using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineScript : MonoBehaviour
{
    [SerializeField]
    public List<Transform> slots;
    public List<NumberScript> inputs;
    public UnityEvent purpose;
    public CraneMovement crane;
    RepeatMachine rm;

    // Start is called before the first frame update
    void Start()
    {
        //slots = new List<Transform>();
        //inputs = new List<NumberScript>();
        rm = gameObject.GetComponent<RepeatMachine>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform CanInsert()
    {
        //Debug.Log("Inputs=" +inputs.Count);

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
        crane.holding = null;

        inputs.Add(num);
        //reparent the number
        Transform numTransform = num.transform;
        numTransform.SetParent(this.transform);
        numTransform.localPosition = slots[inputs.Count - 1].transform.localPosition;
        //set new local coords

        //Debug.Log("POS = " + numTransform.localPosition);

        if(inputs.Count == slots.Count)
        {
            //Do the thing the machine does
            //Debug.Log("Attempting to Invoke purpose");
            if (!rm)
            {
                purpose.Invoke();
            }
            
        }
    }

    public NumberScript CanRemove()
    {
        if(inputs.Count > 0)
        {
            return inputs[inputs.Count-1];
        }
        //Debug.Log("Inputs= "+inputs.Count);
        return null;
    }

    public NumberScript Remove(Transform craneTransform)
    {
        NumberScript num = CanRemove();
        if (num)
        {
            Transform numTransform = num.transform;

            if (rm) // this is the repeat machine
            {
                purpose.Invoke();
                crane.holding = null;
                return null;
            }

            //reparent the number to the crane
            numTransform.SetParent(craneTransform);

            //set the new local coordinates of the number
            numTransform.localPosition = new Vector3(0, -0.2f, 0);

            //remove the number from the inputs list
            inputs.Remove(num);

            //return the number
            return num;
        }
        return null;
    }
}
