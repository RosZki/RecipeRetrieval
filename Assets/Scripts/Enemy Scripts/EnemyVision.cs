using UnityEngine;
using System.Collections.Generic;

public class EnemyVision : MonoBehaviour {

    private List<GameObject> inRangePlayer;
    private GameObject enemyObject;
    
    void Awake () {
        inRangePlayer = new List<GameObject>();
        enemyObject = transform.parent.gameObject;
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Blockade")
        {
            if (!transform.GetComponentInParent<EnemyScript>().isChasingPlayer)
            {
                transform.parent.GetComponent<EnemyScript>().Flip();
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            if (!inRangePlayer.Contains(other.gameObject))
            {
                if (!other.gameObject.GetComponent<PlayerControl>().isHiding)
                {
                    Debug.Log("Staht");
                    enemyObject.GetComponent<EnemyScript>().StartChase();
                    inRangePlayer.Add(other.gameObject);
                }               
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inRangePlayer.Contains(other.gameObject))
            {
                Debug.Log("Stahp");
                enemyObject.GetComponent<EnemyScript>().StopChase();
                inRangePlayer.Remove(other.gameObject);
            }
        }
    }
}
