using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settgins_open : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;
    void Start()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenSettigins()
    {
        settings.SetActive(!settings.activeSelf);
        menu.SetActive(!menu.activeSelf);
    }
}
