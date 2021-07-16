using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CraneMovement : MonoBehaviour
{
    Tween movement;
    public float speed = 0.2f;
    float target;

    GameObject[] columns;
    int currentColumn;
    MachineManagerScript manager;
    
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        manager = GetComponent<MachineManagerScript>();
        columns = manager.columns;

        currentColumn = manager.getNearestMachine(transform.position);
        Debug.Log("CURRENT COLUMN = "+currentColumn);

        movement = transform.DOMove(transform.position, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && !movement.IsActive())//!moving_down && !moving_left && !moving_right)
        {
            Debug.Log("RIGHT to "+ (currentColumn+1));
            if (currentColumn < columns.Length-1)
            {
                currentColumn = currentColumn + 1;
                target = columns[currentColumn].transform.position.x;
                movement = transform.DOMoveX(target, speed);
            }
        }

        if (Input.GetKeyDown("left") && !movement.IsActive())
        {
            Debug.Log("LEFT to "+(currentColumn-1));
            if (currentColumn > 0)
            {
                currentColumn = currentColumn - 1;
                target = columns[currentColumn].transform.position.x;
                movement = transform.DOMoveX(target, speed);
            }

        }


        if (Input.GetKeyDown("down") && !movement.IsActive())
        {
            GameObject currentMachine = columns[currentColumn];
            MachineScript currentMachineScript = currentMachine.GetComponent<MachineScript>();
            //Debug.Log("MACHINECSRIPTNULL?? "+currentMachineScript);
            Transform slot = currentMachineScript.CanInsert();

            if (slot)
            {
                target = slot.position.y;
                float startY = transform.position.y;
                movement = transform.DOMoveY(target, speed);//.DOMoveY(startY, speed);
            }
        }

    }
}
