using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2 : MonoBehaviour
{
    public Material ButtonDark;
    public Material ButtonLight;
    public GameObject L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, L13, Big, Small;
    public bool isPracticeArena = false;

    void Start()
    {
        L1.GetComponent<MeshRenderer>().material = ButtonDark;
        L2.GetComponent<MeshRenderer>().material = ButtonDark;
        L3.GetComponent<MeshRenderer>().material = ButtonDark;
        L4.GetComponent<MeshRenderer>().material = ButtonDark;
        L5.GetComponent<MeshRenderer>().material = ButtonDark;
        L6.GetComponent<MeshRenderer>().material = ButtonDark;
        L7.GetComponent<MeshRenderer>().material = ButtonDark;
        L8.GetComponent<MeshRenderer>().material = ButtonDark;
        L9.GetComponent<MeshRenderer>().material = ButtonDark;
        L10.GetComponent<MeshRenderer>().material = ButtonDark;
        L11.GetComponent<MeshRenderer>().material = ButtonDark;
        L12.GetComponent<MeshRenderer>().material = ButtonDark;
        L13.GetComponent<MeshRenderer>().material = ButtonDark;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            L1.GetComponent<MeshRenderer>().material = ButtonLight;
            L2.GetComponent<MeshRenderer>().material = ButtonLight;
            L3.GetComponent<MeshRenderer>().material = ButtonLight;
            L4.GetComponent<MeshRenderer>().material = ButtonLight;
            L5.GetComponent<MeshRenderer>().material = ButtonLight;
            L6.GetComponent<MeshRenderer>().material = ButtonLight;
            L7.GetComponent<MeshRenderer>().material = ButtonLight;
            L8.GetComponent<MeshRenderer>().material = ButtonLight;
            L9.GetComponent<MeshRenderer>().material = ButtonLight;
            L10.GetComponent<MeshRenderer>().material = ButtonLight;
            L11.GetComponent<MeshRenderer>().material = ButtonLight;
            L12.GetComponent<MeshRenderer>().material = ButtonLight;
            L13.GetComponent<MeshRenderer>().material = ButtonLight;
        }

        if (Input.GetMouseButtonDown(0) && isPracticeArena)
        {
            SceneManager.LoadScene("Practice arena");
        }
        else
        {
            L1.GetComponent<MeshRenderer>().material = ButtonDark;
            L2.GetComponent<MeshRenderer>().material = ButtonDark;
            L3.GetComponent<MeshRenderer>().material = ButtonDark;
            L4.GetComponent<MeshRenderer>().material = ButtonDark;
            L5.GetComponent<MeshRenderer>().material = ButtonDark;
            L6.GetComponent<MeshRenderer>().material = ButtonDark;
            L7.GetComponent<MeshRenderer>().material = ButtonDark;
            L8.GetComponent<MeshRenderer>().material = ButtonDark;
            L9.GetComponent<MeshRenderer>().material = ButtonDark;
            L10.GetComponent<MeshRenderer>().material = ButtonDark;
            L11.GetComponent<MeshRenderer>().material = ButtonDark;
            L12.GetComponent<MeshRenderer>().material = ButtonDark;
            L13.GetComponent<MeshRenderer>().material = ButtonDark;
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
            isPracticeArena = true;
        }
    }

    void OnMouseExit()
    {
        if (L1.name == "P")
        {
            isPracticeArena = false;
        }

        Big.SetActive(false);
        Small.SetActive(true);

        L1.GetComponent<MeshRenderer>().material = ButtonDark;
        L2.GetComponent<MeshRenderer>().material = ButtonDark;
        L3.GetComponent<MeshRenderer>().material = ButtonDark;
        L4.GetComponent<MeshRenderer>().material = ButtonDark;
        L5.GetComponent<MeshRenderer>().material = ButtonDark;
        L6.GetComponent<MeshRenderer>().material = ButtonDark;
        L7.GetComponent<MeshRenderer>().material = ButtonDark;
        L8.GetComponent<MeshRenderer>().material = ButtonDark;
        L9.GetComponent<MeshRenderer>().material = ButtonDark;
        L10.GetComponent<MeshRenderer>().material = ButtonDark;
        L11.GetComponent<MeshRenderer>().material = ButtonDark;
        L12.GetComponent<MeshRenderer>().material = ButtonDark;
        L13.GetComponent<MeshRenderer>().material = ButtonDark;
    }
}
