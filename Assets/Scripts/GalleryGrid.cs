using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GalleryGrid : MonoBehaviour
{
    public float spacing = 16f;

    void Start()
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();

        int columns = Screen.width > Screen.height ? 3 : 2;
        float width = ((RectTransform)transform).rect.width;

        print(columns);

        float cellSize = (width - spacing * (columns - 1)) / columns;

        grid.cellSize = new Vector2(cellSize, cellSize);
        grid.spacing = new Vector2(spacing, spacing);
    }
}
