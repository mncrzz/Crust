using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject settings;
    void Start()
    {
        settings.SetActive(false);
    }

    public void OpenSettigins()
    {
        settings.SetActive(!settings.activeSelf);
    }
    public void CloseMenu()
    {
        settings.SetActive(false);
    }
}
