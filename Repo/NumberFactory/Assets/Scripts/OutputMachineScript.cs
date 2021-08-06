using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutputMachineScript : MonoBehaviour
{
    [SerializeField]
    public int expecting;
    public MachineScript machine;
    public Camera cam;
    public JsonReader levels;

    public void EndLevelIfMatch()
    {
        Debug.Log("EndLevelIfMatch function called");
        if(machine.inputs[0].number == expecting)
        {
            levels.IncrementCurrentLevel();
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnGUI()
    {
        Transform tr = machine.slots[0];
        Vector3 pos = new Vector3(tr.position.x, -tr.position.y, tr.position.z);
        Vector3 screen_coord = cam.WorldToScreenPoint(pos);

        //Debug.Log("TEXT = "+label_text+ " POSITION = "+screen_coord.x+", "+screen_coord.y);

        GUI.Label(new Rect(screen_coord.x-4, screen_coord.y-10, 100, 100), ""+expecting);
    }
}
