using UnityEngine;
using System.Collections.Generic;

public class EnemyVision : MonoBehaviour {

    public float timeBeforeFlip;

    private List<GameObject> inRangePlayer;
    private GameObject enemyObject;

    private float currTimeBeforeFlip;
    
    void Awake () {
        inRangePlayer = new List<GameObject>();
        enemyObject = transform.parent.gameObject;
        currTimeBeforeFlip = 0.0f;
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!inRangePlayer.Contains(other.gameObject))
            {
                if (!other.gameObject.GetComponent<PlayerControl>().isHiding)
                {
                    enemyObject.GetComponent<EnemyScript>().StartChase();
                    currTimeBeforeFlip = 0.0f;
                    inRangePlayer.Add(other.gameObject);
                }               
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Blockade")
        {
            currTimeBeforeFlip += Time.deltaTime;
            if (!enemyObject.GetComponent<EnemyScript>().isChasingPlayer && currTimeBeforeFlip >= timeBeforeFlip)
            {
                enemyObject.GetComponent<EnemyScript>().Flip();
                currTimeBeforeFlip = 0.0f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inRangePlayer.Contains(other.gameObject))
            {
                enemyObject.GetComponent<EnemyScript>().StopChase();
                currTimeBeforeFlip = 0.0f;
                inRangePlayer.Remove(other.gameObject);
            }
        }
    }
}
