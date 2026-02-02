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

        int columns = IsTablet() ? 3 : 2;
        grid.constraintCount = columns;
        float width = Screen.width;
        float cellSize = (width - spacing * (columns - 1)) / columns;

        grid.cellSize = new Vector2(cellSize, cellSize);
        grid.spacing = new Vector2(spacing, spacing);
    }

    public bool IsTablet()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float dpi = Screen.dpi;

        if (dpi <= 0) dpi = 160;

        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2)) / dpi;

        return diagonalInches > 6.7f;
    }
}

public enum GalleryFilter
{
    All,
    Odd,
    Even
}
