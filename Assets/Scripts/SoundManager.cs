using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource shot;
    public AudioSource build;
    public AudioSource bonk;
    public AudioSource axeUse;
    public AudioSource pickaxe;
    public AudioSource revolver;
    public AudioSource rocket;
    public AudioSource nullSND;
    public bool isAxe = false;
    public static SoundManager Instance;

    void Awake()
    {
        Instance = this;
    }
    public void PlaySoundBTN()
    {
        if (FastInventory.Instance.activeItem.name == "Пистолет")
        {
            shot.Play();
        }
        if (FastInventory.Instance.activeItem.name == "План")
        {
            build.Play();
        }
        if (FastInventory.Instance.activeItem.name == "Конфета")
        {
            bonk.Play();
        }
        if (FastInventory.Instance.activeItem.name == "Кирка")
        {
            pickaxe.Play();
        }
        if (FastInventory.Instance.activeItem.name == "Револьвер")
        {
            revolver.Play();
        }
        if (FastInventory.Instance.activeItem.name == "Ракетница")
        {
            rocket.Play();
        }
    }
    public void PlaySoundAxe()
    {
        if(isAxe)
        {
            axeUse.Play();
            isAxe = false;
        }
    }
    public void PlaySoundNull()
    {
        nullSND.Play();
    }
}
