using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [SerializeField] private GameObject _imagePopup;
    [SerializeField] private GameObject _premiumPopup;
    [SerializeField] private Image _popupImage;

    void Awake() => Instance = this;

    public void ShowImage(Sprite sprite)
    {
        _popupImage.sprite = sprite;
        _imagePopup.SetActive(true);
    }

    public void ShowPremium()
    {
        _premiumPopup.SetActive(true);
    }

    public void CloseAll()
    {
        _imagePopup.SetActive(false);
        _premiumPopup.SetActive(false);
    }
}
