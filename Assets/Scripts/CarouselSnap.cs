using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class CarouselSnap : MonoBehaviour, IEndDragHandler
{
    public float snapSpeed = 12f;
    public float autoDelay = 5f;

    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _content;
    [SerializeField] private RectTransform[] _banners;

    [SerializeField] private Sprite _ellipseActive;
    [SerializeField] private Sprite _ellipseInactive;

    [SerializeField] private Image[] _dots;

    private int _targetIndex;
    private bool _snapping;
    private float _autoTimer;

    private void Start()
    {
        _targetIndex = 1;
        DotsRedraw();
    }

    private void DotsRedraw()
    {
        for (int i = 0; i < _dots.Length; i++)
        {
            _dots[i].sprite = _ellipseInactive;
        }
        if (_targetIndex == 0)
        {
            _dots[0].sprite = _ellipseActive;
            return;
        }
        if (_targetIndex == _banners.Length - 1)
        {
            _dots[_dots.Length - 1].sprite = _ellipseActive;
            return;
        }
        _dots[1].sprite = _ellipseActive;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float nearest = float.MaxValue;

        for (int i = 0; i < _banners.Length; i++)
        {
            float dist = Mathf.Abs(_content.localPosition.x + _banners[i].localPosition.x);

            if (dist < nearest)
            {
                nearest = dist;
                _targetIndex = i;
                DotsRedraw();
            }
        }

        _snapping = true;
    }

    void Update()
    {
        // --------------------------------------код автопрокрутки
        if (Input.touchCount > 0) return;

        _autoTimer += Time.deltaTime;
        if (_autoTimer > autoDelay)
        {
            _autoTimer = 0;
            _targetIndex = (_targetIndex + 1) % _banners.Length;
            DotsRedraw();
            _snapping = true;
        }

        // --------------------------------------код автопрокрутки

        if (!_snapping) return;
        _autoTimer = 0;
        Vector3 targetPos = new Vector3(-_banners[_targetIndex].localPosition.x, _content.localPosition.y, 0);

        _content.localPosition = Vector3.Lerp(
            _content.localPosition,
            targetPos,
            Time.deltaTime * snapSpeed
        );

        if (Vector3.Distance(_content.localPosition, targetPos) < 1f)
            _snapping = false;
    }
}
