using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIcon : MonoBehaviour
{
    [SerializeField] private Image[] icons;
    private void Start()
    {
        EnabledIcon();
    }
    private void EnabledIcon()
    {
        if (PlayerPrefs.HasKey("dark"))
        {
            icons[0].enabled = true;
            icons[1].enabled = false;
        }
        else
        {
            icons[0].enabled = false;
            icons[1].enabled = true;
        }
    }

    public void EnabledIcons()
    {
        foreach (var item in icons)
        {
            item.enabled = !item.enabled;
        }
    }
}
