using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class PauseMenuScript : MonoBehaviour {

    public Button[] buttonsToDisable;
    public GameObject[] stuffToEnable;

    public void Pause()
    {
        Time.timeScale = 0;
        foreach(Button b in buttonsToDisable)
        {
            b.gameObject.SetActive(false);
        }
        foreach (GameObject g in stuffToEnable)
        {
            g.SetActive(true);
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        foreach (Button b in buttonsToDisable)
        {
            b.gameObject.SetActive(true);
        }
        foreach (GameObject g in stuffToEnable)
        {
            g.SetActive(false);
        }
    }

    public void GoBackToLevelSelect()
    {
        CameraFader.FadeOutMain();
        CameraFader.FadeInMain();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("World Select");
    }

    public void Exit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
}
