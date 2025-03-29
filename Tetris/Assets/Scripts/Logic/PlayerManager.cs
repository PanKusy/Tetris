using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public GridManager gridManager;
    private BlockSpawner spawner;

    public Vector3 spawnPoint;

    private void Start()
    {
        spawner = FindFirstObjectByType<BlockSpawner>();
        gridManager.InitializeGrid(spawnPoint);
        SpawnBlock(player);
    }

    private void OnEnable()
    {
        EventManager.instance.onReachedEnd += SpawnBlock;
    }
    private void OnDisable()
    {
        EventManager.instance.onReachedEnd -= SpawnBlock;
    }

    private void SpawnBlock(Player player)
    {
        if (player == this.player)
            spawner.SpawnBlock(spawnPoint, player, gridManager);
    }
}
