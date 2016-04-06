using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public float timeWait = 0.0f;

    private bool canInteract = false;

    void Update()
    {
        if(timeWait <= 0)
        {
            canInteract = true;
        }
        if (canInteract)
        {
            if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0))
            {
                CameraFader.FadeOutMain();
                //CameraFader.FadeInMain();
                SceneManager.LoadScene("World Select");
            }
        }
        if(timeWait > 0)
        {
            timeWait -= Time.deltaTime;
        }
    }

}
