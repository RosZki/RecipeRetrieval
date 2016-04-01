using UnityEngine;
using System.Collections;

public class ObjectLaser : MonoBehaviour {

    public bool isOn;

    private Animator anim;
    private BoxCollider2D col;

    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    public void SwitchState()
    {
        if (isOn)
        {
            anim.SetTrigger("TurnOff");
            col.enabled = false;
        }
        else
        {
            anim.SetTrigger("TurnOn");
            col.enabled = true;
        }
        isOn = !isOn;
    }

}
