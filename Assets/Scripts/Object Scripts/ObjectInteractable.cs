using UnityEngine;
using System.Collections;

public class ObjectInteractable : MonoBehaviour {

    private Color originalColor;
    private Renderer render;

    private Color highlightColor;

	// Use this for initialization
	void Awake () {
        render = this.GetComponent<Renderer>();
        originalColor = render.material.color;
        highlightColor = new Color(242/255.0f, 249 / 255.0f, 143 / 255.0f);
       // highlightColor = Color.blue;
	}
	
	public void Highlight()
    {
        render.material.color = highlightColor;
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
