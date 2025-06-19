using UnityEngine;

public class Crafting : MonoBehaviour
{
    public void CraftPlan()
    {
        if(FastInventory.Instance.wood >= 25 || FastInventory.Instance.wood == 25)
        {
            FastInventory.Instance.AddItem("plan");

            FastInventory.Instance.wood -= 25;
            if(FastInventory.Instance.wood <= 0)
            {
                FastInventory.Instance.wood = 0;
            }
        }
    }
    public void CraftPickaxe()
    {
        if(FastInventory.Instance.wood >= 50 || FastInventory.Instance.wood == 50)
        {
            FastInventory.Instance.AddItem("pickaxe");

            FastInventory.Instance.wood -= 50;
            if(FastInventory.Instance.wood <= 0)
            {
                FastInventory.Instance.wood = 0;
            }
        }
    }
    public void CraftRevolver()
    {
        if(FastInventory.Instance.wood >= 100 || FastInventory.Instance.wood == 100)
        {
            FastInventory.Instance.AddItem("revolver");

            FastInventory.Instance.wood -= 100;
            if(FastInventory.Instance.wood <= 0)
            {
                FastInventory.Instance.wood = 0;
            }
        }
    }
}
