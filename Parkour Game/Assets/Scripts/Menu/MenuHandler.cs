using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    void Start()
    {
        // set PLAY-Big and EXIT-Big to disabled
        // set PLAY and EXIT to enabled
        GameObject.Find("PLAY-Big").SetActive(false);
        GameObject.Find("EXIT-Big").SetActive(false);
        GameObject.Find("PLAY").SetActive(true);
        GameObject.Find("EXIT").SetActive(true);

        GameObject.Find("Menu2").SetActive(false);
    }
}
