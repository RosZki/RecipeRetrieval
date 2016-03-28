using UnityEngine;
using System.Collections;

public class ObjectHide : MonoBehaviour {

    public void Hide(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerControl>().StartHide(transform.position);
    }

}
