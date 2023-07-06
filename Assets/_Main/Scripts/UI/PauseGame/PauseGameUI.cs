using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameUI : MonoBehaviour
{
    public void ClosePause()
    {
        this.gameObject.SetActive(false);
    }
}
