using Photon.Pun.Demo.Asteroids;
using UnityEngine;

public class BuildChecker : MonoBehaviour
{
    public GameObject buildDeny;
    public GameObject buildAllow;
    public static BuildChecker Instance;
    public bool canBuild = false;
    public GameObject menu_build;
    public GameObject rotate;
    public GameObject remove;
    public GameObject build_plan;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        buildDeny.SetActive(true);
        buildAllow.SetActive(false);
        remove.SetActive(false);
        rotate.SetActive(false);
        menu_build.SetActive(false);
        canBuild = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "buildAllowTrigger")
        {
            if(build_plan.activeSelf == true)
            {
                buildDeny.SetActive(false);
                buildAllow.SetActive(true);
                remove.SetActive(true);
                rotate.SetActive(true);
                menu_build.SetActive(true);
                canBuild = true;
            }
            if (build_plan.activeSelf == false)
            {
                buildDeny.SetActive(true);
                buildAllow.SetActive(false);
                remove.SetActive(false);
                rotate.SetActive(false);
                menu_build.SetActive(false);
                canBuild = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "buildAllowTrigger")
        {
            buildDeny.SetActive(true);
            buildAllow.SetActive(false);
            buildDeny.SetActive(true);
            buildAllow.SetActive(false);
            remove.SetActive(false);
            rotate.SetActive(false);
            menu_build.SetActive(false);
            canBuild = false;
        }
    }
}
