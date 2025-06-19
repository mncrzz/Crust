using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [Header("Анимации")]
    public Animator arms_axe;
    public Animator arms_revolver;
    public Animator arms_plan;

    public void PlayAnimBTN()
    {
        if (FastInventory.Instance.activeItem.name == "Пистолет")
        {

        }
        if (FastInventory.Instance.activeItem.name == "План")
        {
            arms_plan.SetTrigger("PlanPlay");
        }
        if (FastInventory.Instance.activeItem.name == "Конфета")
        {

        }
        if (FastInventory.Instance.activeItem.name == "Топор")
        {
            arms_axe.SetTrigger("AxePlay");
        }
        if (FastInventory.Instance.activeItem.name == "Кирка")
        {

        }
        if (FastInventory.Instance.activeItem.name == "Револьвер")
        {
            arms_revolver.SetTrigger("RevolverPlay");
        }
        if (FastInventory.Instance.activeItem.name == "Ракетница")
        {

        }
    }
}
