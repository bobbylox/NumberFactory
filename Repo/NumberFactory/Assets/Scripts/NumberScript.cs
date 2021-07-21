using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public float number;
    public Camera cam;
    int myColumn = 0; // -1 means it's being held by the crane

    void Start()
    {

    }

    void OnGUI()
    {
        Vector3 pos = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);

        GUI.Label(new Rect(screen_coord.x, screen_coord.y, 50, 50), ""+number);

        //""+5 -> "5"
    }
}
