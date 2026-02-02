using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryTabs : MonoBehaviour
{
    public GalleryControl gallery;

    [SerializeField] private Button _allBtn;
    [SerializeField] private Button _oddBtn;
    [SerializeField] private Button _evenBtn;

    public Color activeColor;
    public Color inactiveColor;

    void Start()
    {
        _allBtn.onClick.AddListener(() => Select(GalleryFilter.All));
        _oddBtn.onClick.AddListener(() => Select(GalleryFilter.Odd));
        _evenBtn.onClick.AddListener(() => Select(GalleryFilter.Even));

        Select(GalleryFilter.All);
    }

    void Select(GalleryFilter filter)
    {
        gallery.ApplyFilter(filter);

        SetButton(_allBtn, filter == GalleryFilter.All);
        SetButton(_oddBtn, filter == GalleryFilter.Odd);
        SetButton(_evenBtn, filter == GalleryFilter.Even);
    }

    void SetButton(Button btn, bool active)
    {
        btn.image.color = active ? activeColor : inactiveColor;
    }
}
