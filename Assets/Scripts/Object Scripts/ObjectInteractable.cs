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

    public void Interact(GameObject playerObject)
    {
        if(transform.GetComponentInParent<ObjectHide>() != null)
        {
            transform.GetComponentInParent<ObjectHide>().Hide(playerObject);
        }
    }

}
