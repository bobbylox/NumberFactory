using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public int number;
    public Camera cam;
    GameObject go;

    void Start()
    {
        go = transform.gameObject;
    }

    void OnGUI()
    {
        Vector3 pos = new Vector3(go.transform.position.x, -go.transform.position.y, go.transform.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);

        GUI.Label(new Rect(screen_coord.x, screen_coord.y, 50, 50), ""+number);

        //""+5 -> "5"
    }
}
