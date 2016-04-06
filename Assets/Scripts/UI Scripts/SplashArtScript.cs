using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashArtScript : MonoBehaviour {

    public float timeWait = 0.0f;
    

    void Update()
    {
        if (timeWait <= 0)
        {
            CameraFader.FadeOutMain();
            //CameraFader.FadeInMain();
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            timeWait -= Time.deltaTime;
        }
    }
}
