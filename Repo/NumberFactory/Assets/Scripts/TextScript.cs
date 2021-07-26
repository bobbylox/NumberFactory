using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public string text;
    public Camera cam;
    void OnGUI()
    {
        Vector3 pos = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);
        GUI.Label(new Rect(screen_coord.x, screen_coord.y, 50, 50), "" + text);
    }
}
