using UnityEngine;
using System.Collections;

public class ObjectTravelPoint : MonoBehaviour {

    public GameObject connectedObject;
	
	public void TravelToConnectedObject (GameObject playerObject) {
        playerObject.transform.position = connectedObject.transform.position;
	}
}
