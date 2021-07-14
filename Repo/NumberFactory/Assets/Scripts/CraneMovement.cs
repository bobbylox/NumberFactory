using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraneMovement : MonoBehaviour
{

    bool moving_right;
    bool moving_left;
    bool moving_up;
    bool moving_down;
    public float column_distance = 2.0f;
    float speed = 0.2f;
    float target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            moving_right = true;
            target = transform.position.x + column_distance;
        }



        if (moving_right)
        {
            if (transform.position.x < target)
            {
                transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
            }
            else
            {
                moving_right = false;
            }
        }


        if (Input.GetKeyDown("left"))
        {
            moving_left = true;
            target = transform.position.x - column_distance;
        }



        if (moving_left)
        {
            if (transform.position.x > target)
            {
                transform.Translate(new Vector3(Time.deltaTime * -speed, 0, 0));
            }
            else
            {
                moving_left = false;
            }
        }


        if (Input.GetKeyDown("down"))
        {
            moving_down = true;
            target = transform.position.y - column_distance;
            moving_up = true;

        }



        if (moving_down)
        {
            if (transform.position.y > target)
            {
                transform.Translate(new Vector3(0, Time.deltaTime * -speed, 0));
                //transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
            }
            else
            {
                moving_down = false;
            }
        }



    }
}
