using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public Color ActiveColor;
    public Color InactiveColor;
    public Color InactiveTextColor;

    [SerializeField] private Image _tabIndicator;
    [SerializeField] private TextMeshProUGUI _tabText;

    public void SetButton(bool active)
    {
        print("set button");
        _tabIndicator.color = active ? ActiveColor : InactiveColor;
        _tabText.color = active ? ActiveColor : InactiveTextColor;
    }
}
