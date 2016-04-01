using UnityEngine;
using System.Collections;

public class ObjectInteractable : MonoBehaviour {

    private Color originalColor;
    private Renderer render;

	// Use this for initialization
	void Awake () {
        render = this.GetComponent<Renderer>();
        originalColor = render.material.color;
	}
	
	public void Highlight()
    {
        render.material.color = Color.yellow;
    }

    public void UnHighlight()
    {
        render.material.color = originalColor;
    }

    public bool Interact(GameObject playerObject)
    {
        if(GetComponentInParent<ObjectHide>() != null)
        {
            GetComponentInParent<ObjectHide>().Hide(playerObject);
            return true;
        }
        else if(GetComponentInParent<ObjectTravelPoint>() != null)
        {
            GetComponentInParent<ObjectTravelPoint>().TravelToConnectedObject(playerObject);
            return true;
        }
        else if(GetComponentInParent<ObjectSwitch>() != null)
        {
            GetComponentInParent<ObjectSwitch>().TurnSwitch();
            GetComponentInParent<ObjectSwitch>().StartCooldown();
            return true;
        }
        else if (GetComponentInParent<ObjectExit>() != null)
        {
             return GetComponentInParent<ObjectExit>().Exit(playerObject);
           
        }
        return false;
    }

}
