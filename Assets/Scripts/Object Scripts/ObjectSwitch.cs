using UnityEngine;
using System.Collections;

public class ObjectSwitch : MonoBehaviour {

    public GameObject[] listObjects;
    public float timer;

    private Animator anim;
    private bool isOn;
    private bool hasTimerStarted;

    private float currTimer;

    void Awake()
    {
        hasTimerStarted = false;
        isOn = true;
        anim = GetComponent<Animator>();
        currTimer = timer;
    }

    void Update()
    {
        if (hasTimerStarted)
        {
            if(currTimer <= 0)
            {
                currTimer = timer;
                hasTimerStarted = false;
                TurnSwitch();
            }
            else
            {
                currTimer -= Time.deltaTime;
            }
        }
    }

    public void StartCooldown()
    {
        hasTimerStarted = true;
    }

    public void TurnSwitch()
    {
        foreach(GameObject g in listObjects)
        {
            if(g.GetComponent<ObjectLaser>() != null)
            {
                g.GetComponent<ObjectLaser>().SwitchState();
            }
        }
        if (isOn)
        {
            anim.SetTrigger("TurnOff");
        }
        else
        {
            anim.SetTrigger("TurnOn");
        }
        isOn = !isOn;
    }

}
