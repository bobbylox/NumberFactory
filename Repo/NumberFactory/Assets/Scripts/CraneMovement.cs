using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CraneMovement : MonoBehaviour
{
    Tween movement;
    public float speed = 0.01f;
    float target;

    GameObject[] columns;
    int currentColumn;
    MachineManagerScript manager;
    public NumberScript holding;

    public SequenceScript sequence;
    private Claw claw;
    


    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        manager = GetComponent<MachineManagerScript>();
        columns = manager.columns;
        currentColumn = manager.getNearestMachine(transform.position);
        Debug.Log("CURRENT COLUMN = "+currentColumn);
        movement = transform.DOMove(transform.position, 0);
        claw = GetComponent<Claw>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))//!moving_down && !moving_left && !moving_right)
        {
            Right();
        }

        if (Input.GetKeyDown("left"))
        {
            Left();
        }


        if (Input.GetKeyDown("down"))
        {
            Down();

        }

    }

    public void Right()
    {
        //Debug.Log("RIGHT to "+ (currentColumn+1));
         if (movement.IsActive())
        {
            return;
        }
        if (currentColumn < columns.Length - 1)
        {
            currentColumn = currentColumn + 1;
            while (!columns[currentColumn].gameObject.activeSelf)
            {
                currentColumn = currentColumn + 1;
            }
            target = columns[currentColumn].transform.position.x;
            movement = transform.DOMoveX(target, speed);
        }
    }

    public void Left()
    {
        //Debug.Log("LEFT to "+(currentColumn-1));
        if (movement.IsActive())
        {
            return;
        }
        if (currentColumn > 0)
        {
            currentColumn = currentColumn - 1;
            while (!columns[currentColumn].gameObject.activeSelf)
            {
                currentColumn = currentColumn - 1;
            }
            target = columns[currentColumn].transform.position.x;
            movement = transform.DOMoveX(target, speed);
        }
    }

    public void Down()
    {
        if (movement.IsActive())
        {
            return;
        }
        if (!sequence.CheckLimit())
        {//check we're not over limit
            //If we're over the limit, reset the scene
            SceneManager.LoadScene("GameScene");
        }

        GameObject currentMachine = columns[currentColumn];
        MachineScript currentMachineScript = currentMachine.GetComponent<MachineScript>();
        //Debug.Log("MACHINECSRIPTNULL?? "+currentMachineScript);
        bool dropoff = false;
        Transform slot;

        if (holding)
        {
            slot = currentMachineScript.CanInsert();
            dropoff = true;
        }
        else
        {
            //Debug.Log("CurrentMachineScript "+currentMachineScript);
            if (currentMachineScript.CanRemove())
            {
                slot = currentMachineScript.CanRemove().transform;
            }
            else
            {
                slot = null;
            }
        }
        //Debug.Log("Dropping off? "+dropoff);
        if (dropoff && slot) //putting down a number into an empty slot
        {
            target = slot.position.y;
            float startY = transform.position.y;
            movement = transform.DOMoveY(target, speed);//.DOMoveY(startY, speed);
            movement.OnComplete(() =>
            {
                //using this temp allows the machine to change what we're holding
                //NumberScript tempHolding = holding;
                currentMachineScript.Insert(holding);
                movement = transform.DOMoveY(startY, speed);
            });

            sequence.AddStep(currentMachineScript.gameObject.GetComponent<MachineLabel>());
        }
        else if (slot)
        { //picking up a number from a slot
            target = slot.position.y;
            float startY = transform.position.y;
            movement = transform.DOMoveY(target, speed);//.DOMoveY(startY, speed);

            //get the number
            movement.OnComplete(() => { 
                holding = currentMachineScript.Remove(transform); 
                movement = transform.DOMoveY(startY, speed);
                Debug.Log("Closing Claw");
                claw.Close();
            });
            sequence.AddStep(currentMachineScript.gameObject.GetComponent<MachineLabel>());
        }
        else //no number held, no number in slot
        {

        }
    }

    public void GoToMachine(MachineLabel label)
    {
        Debug.Log("Going to machine "+label.label_text);
        int direction = manager.GetDirection(label, currentColumn);
        if(direction == 0)
        {
            Down();
        }
        else if(direction == -1)
        {
            Left();
            //yield return new WaitForSeconds(speed);
            //GoToMachine(label);
        }
        else if (direction == 1)
        {
            Right();
            //yield return new WaitForSeconds(speed);
            //GoToMachine(label);
        }
    }

    public void AbortMovement()
    {
        movement.Kill();
    }


}
