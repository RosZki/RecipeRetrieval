using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonInteractCooldown : MonoBehaviour {

    public GameObject playerObject;

    private PlayerControl playerScript;
    private Image img;
    private bool inCooldown = false;

    // Use this for initialization
    void Awake()
    {
        playerScript = playerObject.GetComponent<PlayerControl>();
        img = GetComponent<Image>();
        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillAmount = 0.0f;
        img.fillOrigin = (int)Image.Origin360.Top;
    }

    void StartCooldown()
    {
        inCooldown = true;
        img.fillAmount = 1.0f;
    }

    void Update()
    {
        if (!playerScript.canInteract && !inCooldown)
        {
            StartCooldown();
        }
        if (inCooldown)
        {
            img.fillAmount -= 1.0f / playerScript.interactCooldown * Time.deltaTime;
        }
        if (img.fillAmount <= 0 && playerScript.currInteractCooldown == playerScript.interactCooldown)
        {
            inCooldown = false;
        }

    }
}
