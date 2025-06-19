using UnityEngine;
using UnityEngine.UI;

public class LinkButton : MonoBehaviour
{
    public string linkURL = "https://t.me/dimatit_YG";

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenLink);
    }

    void OpenLink()
    {
        Application.OpenURL(linkURL);
    }
}

