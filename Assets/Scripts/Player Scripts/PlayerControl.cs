using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float jumpCooldown;
    public float interactCooldown;

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool isHiding = false;
    
    [HideInInspector]
    public bool canJump = true;
    [HideInInspector]
    public float currJumpCooldown;

    [HideInInspector]
    public bool canInteract = true;
    [HideInInspector]
    public float currInteractCooldown;

    private float speed = 10;
    private float jumpForce = 27;

    private Rigidbody2D rb;
    private Animator anim;
    private bool moveLeft, moveRight;

	// Use this for initialization
	void Awake () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        currJumpCooldown = jumpCooldown;
        currInteractCooldown = interactCooldown;
	}
	
    void Update()
    {

        if (!canJump)
        {
            if (currJumpCooldown < 0)
            {
                currJumpCooldown = jumpCooldown;
                canJump = true;
                
            }
            else
            {
                currJumpCooldown -= Time.deltaTime;
            }
        }

        if (!canInteract)
        {
            if (currInteractCooldown < 0)
            {
                currInteractCooldown = interactCooldown;
                canInteract = true;

            }
            else
            {
                currInteractCooldown -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            StartJump();
        }
        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }
        
    }
    
	void FixedUpdate () {

        //Control Script
        float h = 0;

        h = Input.GetAxis("Horizontal");

        if (moveLeft && !moveRight)
            h = -1;

        if (moveRight && !moveLeft)
            h = 1;
        
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if ((h > 0 && !facingRight) || (h < 0 && facingRight))
            Flip();

        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            StopJump();
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
        if (!isHiding)
        {
            moveLeft = true;
            anim.SetTrigger("StartWalk");
        }
        
    }

    public void StopLeft()
    {
        if (!isHiding)
        {
            moveLeft = false;
            anim.SetTrigger("StopWalk");
        }
        
    }

    public void MoveRight()
    {
        if (!isHiding)
        {
            moveRight = true;
            anim.SetTrigger("StartWalk");
        }
       
    }

    public void StopRight()
    {
        if (!isHiding)
        {
            moveRight = false;
            anim.SetTrigger("StopWalk");
        }
    }

    public void StartJump()
    {
        if (!isHiding && canJump)
        {
            anim.SetTrigger("StartJump");
            jump = true;
            canJump = false;
        }
    }

    public void StopJump()
    {
        if (!isHiding)
        {
            anim.SetTrigger("StopJump");
            jump = false;
        }
    }

    public void Interact()
    {
        if (canInteract)
        {
            if (isHiding)
            {
                canInteract = false;
                StopHide();
            }
            else
            {
                if (transform.FindChild("InteractCollider").gameObject.GetComponent<PlayerInteract>().nearest != null)
                {
                    bool hasInteracted = transform.FindChild("InteractCollider").gameObject.GetComponent<PlayerInteract>().nearest.GetComponent<ObjectInteractable>().Interact(transform.gameObject);
                    if (hasInteracted)
                    {
                        canInteract = false;
                    }
                }
            }
        }       
        
    }

    public void StartHide(Vector3 newPos)
    {
        moveLeft = moveRight = false;
        transform.position = newPos;
        isHiding = true;     
        rb.simulated = false;
        GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        anim.SetTrigger("StartHide");
    }

    public void StopHide()
    {
        isHiding = false;
        rb.simulated = true;
        GetComponent<SpriteRenderer>().sortingLayerName = "Characters";
        anim.SetTrigger("StopHide");
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            //Debug.Log("Ouch");
        }
        else
        {
            //Debug.Log("Others");
        }
    }

}
