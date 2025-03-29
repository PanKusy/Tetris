using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GridManager gridManager;
    public BlockSpawner spawner;

    public Vector3 spawnPoint;

    private void Start()
    {
        gridManager.InitializeGrid(spawnPoint);
        spawner.SpawnBlock();
    }

}
