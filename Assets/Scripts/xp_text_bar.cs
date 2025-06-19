using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class xp_text_bar : MonoBehaviour
{
    public Image healthBar;
    public InfoPlayer player;
    public TMP_Text text;

    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<InfoPlayer>();
    }
    void Update()
    {
        healthBar.fillAmount = player.HP;
        float textHP = player.HP;
        textHP = textHP * 100;
        text.text = textHP.ToString();
    }
}
