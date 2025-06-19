using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public GameObject[] objects;
    public int placeBlockValue;
    public void SetPrefab(int id)
    {
        if (FindObjectOfType<BuildManager>().created != null)
            Destroy(FindObjectOfType<BuildManager>().created);
        FindObjectOfType<BuildManager>().prefab = objects[id];
    }
    public void SetPrefab1()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 1 - 1;
            PlaceBlock();

        }
    }
    public void SetPrefab2()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 2 - 1;
            PlaceBlock();
        }
    }
    public void SetPrefab3()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 3 - 1;
            PlaceBlock();
        }
    }
    public void SetPrefab4()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 4 - 1;
            PlaceBlock();
        }
    }
    public void SetPrefab5()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 5 - 1;
            PlaceBlock();
        }
    }
    public void SetPrefab6()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 6 - 1;
            PlaceBlock();
        }
    }
    public void SetPrefab7()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            placeBlockValue = 7 - 1;
            PlaceBlock();
        }
    }
    public void PlaceBlock()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            SetPrefab(placeBlockValue);
        }
    }

}