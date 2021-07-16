using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManagerScript : MonoBehaviour
{

    public GameObject[] columns;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNearestMachine(Vector3 pos)
    {
        float min_dist = 999;
        float dist = 999;
        int closestColumn = 0;
        int index = -1;

        foreach(GameObject go in columns)
        {
            index = index + 1;
            dist = Mathf.Abs(pos.x - go.transform.position.x);
            if(dist < min_dist)
            {
                min_dist = dist;
                closestColumn = index;
            }
        }

        return closestColumn;
    }
}
