using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjectExit : MonoBehaviour {

	public bool Exit(GameObject playerObject)
    {
        if (playerObject.GetComponent<PlayerControl>().isObjectiveComplete)
        {
            CameraFader.FadeOutMain();
            CameraFader.FadeInMain();
            SceneManager.LoadScene("Stage Cleared");
            return true;
        }
        return false;
    }
}
