using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {
    
    private bool isLoad;
    private string level;

    void Awake()
    {
        isLoad = false;
    }

    void Update()
    {
        if (isLoad)
        {
            CameraFader.FadeOutMain();
            //CameraFader.FadeInMain();
            SceneManager.LoadScene(level);
        }
    }

    public void LoadLevel(string levelName)
    {
        level = levelName;
        isLoad = true;
    }

}
