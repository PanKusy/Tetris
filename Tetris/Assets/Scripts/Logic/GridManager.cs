using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;
    public float minX;
    public float maxX;

    public Transform[,] grid;

    public void InitializeGrid(Vector3 spawnPoint)
    {
        width = GameManager.instance.boardWidth;
        height = GameManager.instance.boardHeight;

        minX = spawnPoint.x - width / 2f;
        maxX = spawnPoint.x + width / 2f;

        grid = new Transform[width, height];
        //Debug.Log($"{minX}, {maxX}");
    }


    public Vector2 Round(Vector3 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public bool InsideBorder(Vector2 pos)
    {
        return (int)pos.x >= minX && (int)pos.x < maxX && (int)pos.y >= 0;
    }

    public void AddToGrid(Transform block)
    {
        foreach (Transform child in block)
        {
            Vector2 pos = Round(child.position);
            int gridX = Mathf.RoundToInt(pos.x - minX);
            int gridY = Mathf.RoundToInt(pos.y);

            if (gridX >= 0 && gridX < width && gridY >= 0 && gridY < height)
            {
                grid[gridX, gridY] = child;
                //Debug.Log($"Zapisano segment na pozycji [{gridX}, {gridY}]");
            }
        }
    }

    public bool IsOccupied(Vector2 pos)
    {
        int gridX = Mathf.RoundToInt(pos.x - minX);
        int gridY = Mathf.RoundToInt(pos.y);

        if (gridX < 0 || gridX >= width || gridY < 0 || gridY >= height)
            return false;

        return grid[gridX, gridY] != null;

    }

    public void CheckForFullLines()
    {
        for (int y = 0; y < height; y++)
        {
            if (IsLineFull(y))
            {
                DeleteLine(y);
                MoveAllLinesDown(y);
                y--;
            }
        }
    }

    private bool IsLineFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    private void DeleteLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }
    }

    private void MoveAllLinesDown(int startY)
    {
        for (int y = startY + 1; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;

                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }
}
