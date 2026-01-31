using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarouselSnap : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _content;
    [SerializeField] private RectTransform[] _banners;
    public float snapSpeed = 12f;

    private int targetIndex;
    private bool snapping;

    public void OnEndDrag(PointerEventData eventData)
    {
        float nearest = float.MaxValue;
        
        for (int i = 0; i < _banners.Length; i++)
        {
            float dist = Mathf.Abs(_content.localPosition.x + _banners[i].localPosition.x);

            if (dist < nearest)
            {
                nearest = dist;
                targetIndex = i;
                print($"TargetIndex is {targetIndex}");
            }
        }

        snapping = true;
    }

    void Update()
    {
        if (!snapping) return;

        Vector3 targetPos = new Vector3(-_banners[targetIndex].localPosition.x, _content.localPosition.y,0);

        _content.localPosition = Vector3.Lerp(
            _content.localPosition,
            targetPos,
            Time.deltaTime * snapSpeed
        );

        if (Vector3.Distance(_content.localPosition, targetPos) < 1f)
            snapping = false;
    }
}
