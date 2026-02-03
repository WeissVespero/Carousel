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

    [SerializeField] private Tab _allTab;
    [SerializeField] private Tab _oddTab;
    [SerializeField] private Tab _evenTab
        ;

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
        
        _allTab.SetButton(filter == GalleryFilter.All);
        _oddTab.SetButton(filter == GalleryFilter.Odd);
        _evenTab.SetButton(filter == GalleryFilter.Even);
    }
}
