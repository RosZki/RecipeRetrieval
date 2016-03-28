using UnityEngine;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour {

    [HideInInspector]
    public GameObject nearest;

    private List<GameObject> inRangeInteractables;

	void Awake () {
        inRangeInteractables = new List<GameObject>();
	}
	
    void Update()
    {
        nearest = FindNearest();
        if(nearest != null)
        {
            nearest.GetComponent<ObjectInteractable>().Highlight();
        }
    }

	void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.tag == "Interactable")
        {
            if (!inRangeInteractables.Contains(other.gameObject))
            {
                inRangeInteractables.Add(other.gameObject);
            }
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            if (inRangeInteractables.Contains(other.gameObject))
            {
                other.GetComponent<ObjectInteractable>().UnHighlight();
                inRangeInteractables.Remove(other.gameObject);
            }
        }
    }

    private GameObject FindNearest()
    {
        GameObject nearest = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (GameObject obj in inRangeInteractables)
        {
            obj.GetComponent<ObjectInteractable>().UnHighlight();
            Vector2 directionToObject = obj.transform.position - transform.position;
            float dSqrToObject = directionToObject.sqrMagnitude;
            if (dSqrToObject < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToObject;
                nearest = obj;
            }
        }
        return nearest;
    }

}
