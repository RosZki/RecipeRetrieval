﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = false;
    [HideInInspector]
    public bool isChasingPlayer = false;

    private Rigidbody2D rb;
    private float speed = 10;

    private Animator anim;

    // Use this for initialization
    void Awake () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Patrol();

    }

    private void Patrol()
    {
        int h = 0;

        if (facingRight)
        {
            h = 1;
        }
        else
        {
            h = -1;
        }

        rb.velocity = new Vector2(h * speed, rb.velocity.y);
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        // love me senpai <3
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StartChase()
    {
        isChasingPlayer = true;
        anim.SetTrigger("StartRun");
        speed = 15;
    }

    public void StopChase()
    {
        isChasingPlayer = false;
        anim.SetTrigger("StopRun");
        speed = 10;
    }

}