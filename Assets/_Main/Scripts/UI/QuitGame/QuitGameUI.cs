using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameUI : MonoBehaviour
{
    public void CloseQuit()
    {
        this.gameObject.SetActive(false);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
        CloseQuit();
    }
}
