using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static int width = Settings.instance.boardWidth;
    public static int height = Settings.instance.boardHeight;

    public static Transform[,] grid = new Transform[width, height];

    public static Vector2 Round(Vector3 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public static bool InsideBorder(Vector2 pos)
    {
        return (int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0;
    }

    public static void AddToGrid(Transform block)
    {
        foreach (Transform child in block)
        {
            Vector2 pos = Round(child.position);
            if (InsideBorder(pos))
            {
                grid[(int)pos.x, (int)pos.y] = child;

                // Debug info:
                Debug.Log($"Zapisano segment na pozycji [{(int)pos.x}, {(int)pos.y}]");
            }
        }
    }

    public static bool IsOccupied(Vector2 pos)
    {
        if (!InsideBorder(pos)) return false;

        return grid[(int)pos.x, (int)pos.y] != null;
    }

}
