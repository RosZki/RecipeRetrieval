using UnityEngine;
using System.Collections;
//using UnityEditor;

public class QuitScript : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
