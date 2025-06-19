using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour
{
    public List<GameObject> InfoAboutItems = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < InfoAboutItems.Count; i++)
        {
            InfoAboutItems[i].SetActive(false);
        }
    }
    public void ClearMenu()
    {
        for (int i = 0; i < InfoAboutItems.Count; i++)
        {
            InfoAboutItems[i].SetActive(false);
        }
    }
    public void Create_InfoAboutItem(string nameItemInfo)
    {
        for (int i = 0; i < InfoAboutItems.Count; i++)
        {
            InfoAboutItems[i].SetActive(false);
        }
        if(nameItemInfo == "plan")
        {
            InfoAboutItems.Find(p => p.gameObject.name == "InfoAboutItem_PLAN").SetActive(true);
        }
        if(nameItemInfo == "pickaxe")
        {
            InfoAboutItems.Find(p => p.gameObject.name == "InfoAboutItem_PICKAXE").SetActive(true);
        }
        if(nameItemInfo == "revolver")
        {
            InfoAboutItems.Find(p => p.gameObject.name == "InfoAboutItem_REVOLVER").SetActive(true);
        }
    }
}
