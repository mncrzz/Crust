using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FastInventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> _items = new List<GameObject>();

    public TMP_Text[] texts;

    public GameObject activeItem;

    public static FastInventory Instance;

    public TMP_Text woods_text;
    public int wood;

    public void Awake()
    {
        Instance = this;
    }

    public void ChangeItem(int value)
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
        items[value-1].SetActive(true);
        activeItem = items[value-1];
    }

    public void AddItem(string _item)
    {
        if(_item == "plan")
        {
            items.Add(_items.Find(p => p.gameObject.name == "План"));
        }
        if(_item == "pickaxe")
        {
            items.Add(_items.Find(p => p.gameObject.name == "Кирка"));
        }
        if(_item == "revolver")
        {
            items.Add(_items.Find(p => p.gameObject.name == "Револьвер"));
        }
        if(_item == "axe")
        {
            items.Add(_items.Find(p => p.gameObject.name == "Топор"));
        }
    }
    public void Start()
    {
        wood = 0;
    }

    public void Update()
    {
        woods_text.text = "Дерева: " + wood;
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i])
            {
                texts[i].text = items[i].name;
            }
        }
    }
}