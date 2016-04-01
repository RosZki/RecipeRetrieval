using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollViewSnap : MonoBehaviour {

    public RectTransform scrollView;
    public GameObject[] scrollableObjects;
    public RectTransform center;
    public Button leftButton;
    public Button rightButton;

    private float[] distances;
    private bool dragging = false;
    private int objectDistance;
    private int selectedObject;

    void Awake()
    {
        distances = new float[scrollableObjects.Length];

        if(scrollableObjects.Length > 1)
        {
            objectDistance = (int)Mathf.Abs(scrollableObjects[1].GetComponent<RectTransform>().anchoredPosition.x - scrollableObjects[0].GetComponent<RectTransform>().anchoredPosition.x);
        }
        else
        {
            objectDistance = 0;
        }
    }

    void Update()
    {
        for(int i = 0; i< scrollableObjects.Length; i++)
        {
            distances[i] = Mathf.Abs(center.transform.position.x - scrollableObjects[i].transform.position.x);
        }

        float minDist = Mathf.Min(distances);

        for(int i = 0; i< distances.Length; i++)
        {
            if(minDist == distances[i])
            {
                selectedObject = i;
            }
        }

        if (!dragging)
        {
            LerpToButton(selectedObject * -objectDistance);
        }

        if(selectedObject == 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
        }

        if (selectedObject == scrollableObjects.Length-1)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }
    }

    void LerpToButton(int position)
    {
        float newX = Mathf.Lerp(scrollView.anchoredPosition.x, position, Time.deltaTime * 5f);
        Vector2 newPosition = new Vector2(newX, scrollView.anchoredPosition.y);

        scrollView.anchoredPosition = newPosition;
    }

    void MoveToObject(int position)
    {
        Vector2 newPosition = new Vector2(position, scrollView.anchoredPosition.y);

        scrollView.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void StopDrag()
    {
        dragging = false;
    }

    public void MoveLeft()
    {
        if(selectedObject > 0)
            MoveToObject((selectedObject-1) * -objectDistance - objectDistance/8);
    }

    public void MoveRight()
    {
        if(selectedObject < scrollableObjects.Length - 1)
            MoveToObject((selectedObject + 1) * -objectDistance + objectDistance/8);
    }

}
