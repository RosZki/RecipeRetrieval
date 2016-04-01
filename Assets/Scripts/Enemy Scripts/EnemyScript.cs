using UnityEngine;
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
	void FixedUpdate () {

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
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StartChase()
    {
        isChasingPlayer = true;
        anim.speed = 2;
        speed = 15;
    }

    public void StopChase()
    {
        isChasingPlayer = false;
        anim.speed = 0.5f;
        speed = 10;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}
