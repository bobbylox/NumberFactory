using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Claw : MonoBehaviour
{
    private Transform leftClaw;

    // Start is called before the first frame update
    void Start()
    {
        leftClaw = transform.Find("ClawLeft");
    }

    public void Close() {
        leftClaw.DOMoveX( transform.position.x+1f, 0.5f );
    }
}
