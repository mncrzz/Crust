using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_guns : MonoBehaviour
{
    public static change_guns Instance;

    [Header("Guns")]
    //public GameObject konfeta;
    //public GameObject build_plan;
    //public GameObject gun;
    public GameObject konfeta_viewmodel;
    public GameObject build_plan_viewmodel;
    public GameObject gun_viewmodel;
    //[Header("UI")]
    //public GameObject rotateBlock;
    //public GameObject destroyBlock;
    //public GameObject buildMenu;
    [Header("Bool")]
    public bool canBuild;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        konfeta_viewmodel.SetActive(true);
        build_plan_viewmodel.SetActive(false);
        gun_viewmodel.SetActive(false);
    }
    public void ChangeGuns()
    {
        if(konfeta_viewmodel.activeSelf == true)
        {
            konfeta_viewmodel.SetActive(false);
            build_plan_viewmodel.SetActive(true);
            gun_viewmodel.SetActive(false);
            BuildManager.Instance.destroyBlock();
        }

        if (build_plan_viewmodel.activeSelf == true)
        {
            konfeta_viewmodel.SetActive(false);
            build_plan_viewmodel.SetActive(false);
            gun_viewmodel.SetActive(true);

            BuildManager.Instance.destroyBlock();
        }

        if (gun_viewmodel.activeSelf == true)
        {
            konfeta_viewmodel.SetActive(true);
            build_plan_viewmodel.SetActive(false);
            gun_viewmodel.SetActive(false);

            BuildManager.Instance.destroyBlock();
        }
    }
}
