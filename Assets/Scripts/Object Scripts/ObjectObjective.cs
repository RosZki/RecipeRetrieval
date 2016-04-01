using UnityEngine;
using System.Collections;

public class ObjectObjective : MonoBehaviour {

    public GameObject[] listDisabled;

    private void GetObjective(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerControl>().isObjectiveComplete = true;
        transform.gameObject.SetActive(false);
        foreach(GameObject go in listDisabled)
        {
            go.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetObjective(other.gameObject);
        }
    }

}
