using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineLabel : MonoBehaviour
{
    public string label_text;
    public GameObject go;
    public Camera cam;

    void OnGUI()
    {
        Vector3 screen_coord = cam.WorldToScreenPoint(go.transform.position);

        Debug.Log("TEXT = "+label_text+ " POSITION = "+screen_coord.x+", "+screen_coord.y);

        GUI.Label(new Rect(screen_coord.x-4f, screen_coord.y+40f, 100, 100), label_text);
    }
}
