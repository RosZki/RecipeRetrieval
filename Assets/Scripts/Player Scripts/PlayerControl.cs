using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {


    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool isHiding = false;
    
    private float speed = 10;
    private float jumpForce = 730f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool moveLeft, moveRight;

	// Use this for initialization
	void Awake () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Control Script
        int h = 0;

        if (moveLeft && !moveRight)
            h = -1;

        if (moveRight && !moveLeft)
            h = 1;
        
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if ((h > 0 && !facingRight) || (h < 0 && facingRight))
            Flip();

        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            
            jump = false;
        }

    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void MoveLeft()
    {
        moveLeft = true;
        anim.SetTrigger("StartWalk");
    }

    public void StopLeft()
    {
        moveLeft = false;
        anim.SetTrigger("StopWalk");
    }

    public void MoveRight()
    {
        moveRight = true;
        anim.SetTrigger("StartWalk");
    }

    public void StopRight()
    {
        moveRight = false;
        anim.SetTrigger("StopWalk");
    }

    public void StartJump()
    {
        jump = true;
    }

    public void StopJump()
    {
        jump = false;
    }

    public void Interact()
    {
        if (transform.FindChild("InteractCollider").gameObject.GetComponent<PlayerInteract>().nearest != null)
        {
            transform.FindChild("InteractCollider").gameObject.GetComponent<PlayerInteract>().nearest.GetComponent<ObjectInteractable>().Interact(transform.gameObject);
        }
    }

    public void StartHide(Vector3 newPos)
    {
        transform.position = newPos;
        isHiding = true;
        //GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        anim.SetTrigger("StartHide");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            Debug.Log("Ouch");
        }
        else
        {
            Debug.Log("Others");
        }
    }

}
