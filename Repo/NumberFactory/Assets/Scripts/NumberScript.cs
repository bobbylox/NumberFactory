using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public int number;
    public Camera cam;
    public bool hideNumber = false;
    public Vector3 startScale;

    void Awake()
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

    public void SetStartScale(Vector3 newStartScale) {
        //Debug.Log("Setting Start Scale to "+newStartScale);
        startScale = newStartScale;
    }
}
