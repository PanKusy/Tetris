using UnityEngine;

public class Block : MonoBehaviour
{
    public float fallSpeed = 1f;
    private bool isFalling = true;
    public GridManager gridManager;
    public Player player;

    private void Start()
    {
        fallSpeed = GameManager.instance.fallSpeed;
    }

    private void Update()
    {
        if (!isFalling) return;

        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (ShouldStopFalling())
        {
            isFalling = false;
            SnapToGrid();
            gridManager.AddToGrid(transform);
            gridManager.CheckForFullLines();
            EventManager.instance.ReachedEnd(player);
        }
    }

    private bool ShouldStopFalling()
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = gridManager.Round(child.position + Vector3.down * fallSpeed * Time.deltaTime);

            if (pos.y < 0 || gridManager.IsOccupied(pos))
                return true;
        }
        return false;
    }

    private void SnapToGrid()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = child.position;
            child.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), pos.z);
        }
    }
}
