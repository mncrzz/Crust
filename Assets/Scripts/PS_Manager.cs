using UnityEngine;
using UnityEngine.UI;

public class PS_Manager : MonoBehaviour
{
    public Toggle ps;

    void Start()
    {
        if(PlayerPrefs.GetInt("ps") == 1)
        {
            ps.isOn = true;
        }
        else
        {
            ps.isOn = false;
        }
    }
    void Update()
    {
        if(ps.isOn) PlayerPrefs.SetInt("ps", 1);
        if(!ps.isOn) PlayerPrefs.SetInt("ps", 0);
    }
}
