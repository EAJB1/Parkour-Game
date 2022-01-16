using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Material ButtonDark;
    public Material ButtonLight;
    public GameObject L1, L2, L3, L4, Big, Small, Menu1, Menu2, PracticeArena, PracticeArenaBig, Demo, DemoBig;
    public bool isPlay = false, isExit = false, isDemo = false;

    void Start()
    {
        L1.GetComponent<MeshRenderer>().material = ButtonDark;
        L2.GetComponent<MeshRenderer>().material = ButtonDark;
        L3.GetComponent<MeshRenderer>().material = ButtonDark;
        L4.GetComponent<MeshRenderer>().material = ButtonDark;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            L1.GetComponent<MeshRenderer>().material = ButtonLight;
            L2.GetComponent<MeshRenderer>().material = ButtonLight;
            L3.GetComponent<MeshRenderer>().material = ButtonLight;
            L4.GetComponent<MeshRenderer>().material = ButtonLight;
        }

        if (Input.GetMouseButtonDown(0) && isExit)
        {
            Application.Quit();
        }
        else if (Input.GetMouseButtonDown(0) && isPlay)
        {
            Menu1.SetActive(false);
            Menu2.SetActive(true);
            PracticeArena.SetActive(true);
            PracticeArenaBig.SetActive(false);
            Demo.SetActive(true);
            DemoBig.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(0) && isDemo)
        {
            SceneManager.LoadScene("Demo");
        }
        else
        {
            L1.GetComponent<MeshRenderer>().material = ButtonDark;
            L2.GetComponent<MeshRenderer>().material = ButtonDark;
            L3.GetComponent<MeshRenderer>().material = ButtonDark;
            L4.GetComponent<MeshRenderer>().material = ButtonDark;
        }
    }

    void OnMouseEnter()
    {
        Big.SetActive(true);
        Small.SetActive(false);
    }

    void OnMouseOver()
    {
        if (L1.name == "P")
        {
            isPlay = true;
            //Debug.Log("Play " + isPlay);
        }
        else if (L1.name == "E")
        {
            isExit = true;
            //Debug.Log("Exit " + isExit);
        }
        else if (L1.name == "D")
        {
            isDemo = true;
        }
    }

    void OnMouseExit()
    {
        if (L1.name == "P")
        {
            isPlay = false;
        }
        else if (L1.name == "E")
        {
            isExit = false;
        }
        else if (L1.name == "D")
        {
            isDemo = false;
        }

        Big.SetActive(false);
        Small.SetActive(true);

        L1.GetComponent<MeshRenderer>().material = ButtonDark;
        L2.GetComponent<MeshRenderer>().material = ButtonDark;
        L3.GetComponent<MeshRenderer>().material = ButtonDark;
        L4.GetComponent<MeshRenderer>().material = ButtonDark;
    }
}
