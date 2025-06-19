using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMat : MonoBehaviour
{
    public Color []colors;
    public Renderer _renderer;

    void Start()
    {
         InvokeRepeating("ChangeColor", 1.0f, 1.0f);
         _renderer.material.color = colors[Random.Range(0, colors.Length -1)];
    }
}
