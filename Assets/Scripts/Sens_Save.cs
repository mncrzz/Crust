using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sens_Save : MonoBehaviour
{
    public Slider slider;
    public TMP_Text tMP_Text;
    public static Sens_Save Instance;
    void Awake()
    {
      Instance = this;  
    }
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("sens");
        tMP_Text.text = "Чувствительность: " + slider.value;
    }

    void Update()
    {
        PlayerPrefs.SetFloat("sens", slider.value);
        tMP_Text.text = "Чувствительность: " + slider.value;
    }
}
