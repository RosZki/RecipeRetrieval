using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0))
        {
            CameraFader.FadeOutMain();
            CameraFader.FadeInMain();
            SceneManager.LoadScene("World Select");
        }
    }

}
