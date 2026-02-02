using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryControl : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _itemPrefab;

    public int TotalImages = 66;
    public float PreloadOffset = 800f;

    List<GalleryItem> _items = new();
    GalleryFilter _currentFilter = GalleryFilter.All;

    void Start()
    {
        for (int i = 0; i < TotalImages; i++)
        {
            GameObject obj = Instantiate(_itemPrefab, _content);
            GalleryItem item = obj.GetComponent<GalleryItem>();

            item.Setup(i);
            _items.Add(item);
        }

        ApplyFilter(GalleryFilter.All);
    }

    void Update()
    {
        foreach (var item in _items)
        {
            if (!item.gameObject.activeSelf) continue;

            if (item.IsVisible(_scrollRect, PreloadOffset))
                item.TryLoad();
        }
    }

    public void ApplyFilter(GalleryFilter filter)
    {
        _currentFilter = filter;

        foreach (var item in _items)
        {
            bool show = filter switch
            {
                GalleryFilter.All => true,
                GalleryFilter.Odd => item.Index % 2 == 0,   // 1.jpg → index 0
                GalleryFilter.Even => item.Index % 2 == 1,
                _ => true
            };

            item.gameObject.SetActive(show);
        }

        Canvas.ForceUpdateCanvases();
        _scrollRect.verticalNormalizedPosition = 1f;
    }
}
