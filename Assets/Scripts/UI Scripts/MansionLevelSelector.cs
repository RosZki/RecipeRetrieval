using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MansionLevelSelector : MonoBehaviour {

    public GameObject[] MansionLevel1Menu;

    private Animator anim;
    private int currentLevel;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        currentLevel = 1;
    }

    public void LevelOne()
    {
        if(currentLevel == 1)
        {
            anim.SetTrigger("Idle");
            foreach (GameObject g in MansionLevel1Menu)
            {
                g.SetActive(true);
            }
        }
        else
        {
            currentLevel = 1;
            anim.SetTrigger("Level1");
        }
       
    }

    public void LevelTwo()
    {
        currentLevel = 2;
        anim.SetTrigger("Level2");
    }

    public void LevelThree()
    {
        currentLevel = 3;
        anim.SetTrigger("Level3");
    }

    public void Unpause()
    {
        switch (currentLevel)
        {
            case 1:
                foreach (GameObject g in MansionLevel1Menu)
                {
                    g.SetActive(false);                    
                }
                anim.SetTrigger("Level1");
                break;
            case 2: break;
            case 3: break;
            default: break;
        }
        
    }

    public void StartLevel1()
    {
        CameraFader.FadeOutMain();
        //CameraFader.FadeInMain();
        SceneManager.LoadScene("Mansion Level 1");
    }

}
