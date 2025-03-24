using UnityEngine;

public class Block : MonoBehaviour
{
    public float fallSpeed = 1f;
    private bool isFalling = true;

    public BlockSpawner blockSpawner;

    private void Update()
    {
        if (!isFalling) return;

        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (ShouldStopFalling())
        {
            isFalling = false;
            SnapToGrid();
            GridManager.AddToGrid(transform);
            blockSpawner.OnBlockLanded();
        }
    }

    private bool ShouldStopFalling()
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = GridManager.Round(child.position + Vector3.down * fallSpeed * Time.deltaTime);

            // Jeœli pod segmentem jest ju¿ coœ w siatce – stop
            if (pos.y < 0 || GridManager.IsOccupied(pos))
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
