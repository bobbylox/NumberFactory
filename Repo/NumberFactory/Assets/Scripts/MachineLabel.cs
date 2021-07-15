using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineLabel : MonoBehaviour
{
    public string label_text;
    public GameObject go;
    public Camera cam;
    public float x_offset = 0f;
    public float y_offset = 0f;

    void OnGUI()
    {
        Vector3 pos = new Vector3(go.transform.position.x, -go.transform.position.y, go.transform.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);

        //Debug.Log("TEXT = "+label_text+ " POSITION = "+screen_coord.x+", "+screen_coord.y);

        GUI.Label(new Rect(screen_coord.x-x_offset, screen_coord.y+y_offset, 100, 100), label_text);
    }
}
