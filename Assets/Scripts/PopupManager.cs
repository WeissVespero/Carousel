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
    [SerializeField] private Button _backButton;

    void Awake() => Instance = this;

    private void Start()
    {
        _backButton.onClick.AddListener(() => CloseAll());
    }

    public void ShowImage(Sprite sprite)
    {
        _popupImage.sprite = sprite;
        _backButton.gameObject.SetActive(true);
        _imagePopup.SetActive(true);
    }

    public void ShowPremium()
    {
        _backButton.gameObject.SetActive(true);
        _premiumPopup.SetActive(true);
    }

    public void CloseAll()
    {
        _imagePopup.SetActive(false);
        _premiumPopup.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }
}
