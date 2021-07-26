using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public int number;
    public Camera cam;
    int myColumn = 0; // -1 means it's being held by the crane
    public bool hideNumber = false;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void OnGUI()
    {
        Vector3 pos = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);

        //""+5 -> "5"
        if(!hideNumber)
        {
            GUI.Label(new Rect(screen_coord.x, screen_coord.y, 50, 50), "" + number);
        }
    }
    public Vector3 GetStartScale()
    {
        return startScale;
    }
}
