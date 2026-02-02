using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GalleryItem : MonoBehaviour
{
    public int Index;

    [SerializeField] private Image _image;
    [SerializeField] private GameObject _premiumBadge;
    [SerializeField] private Button _button;

    
    bool _loaded;
    bool _isPremium;

    public void Setup(int i)
    {
        Index = i;
        _isPremium = (i + 1) % 4 == 0;
        _premiumBadge.SetActive(_isPremium);
        _button.onClick.AddListener(OnClick);
    }

    public bool IsVisible(ScrollRect scroll, float offset)
    {
        Vector3[] corners = new Vector3[4];
        ((RectTransform)transform).GetWorldCorners(corners);

        Rect viewport = scroll.viewport.rect;
        Vector3 pos = scroll.viewport.InverseTransformPoint(corners[0]);

        return pos.y > -viewport.height - offset && pos.y < offset;
    }

    public void TryLoad()
    {
        if (_loaded) return;
        _loaded = true;
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        string url = $"http://data.ikppbb.com/test-task-unity-data/pics/{Index + 1}.jpg";

        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Texture2D tex = DownloadHandlerTexture.GetContent(req);
            _image.sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );
        }
    }

    public void OnClick()
    {
        print("clicked");
        if (_isPremium)
            PopupManager.Instance.ShowPremium();
        else
            PopupManager.Instance.ShowImage(_image.sprite);
    }
}
