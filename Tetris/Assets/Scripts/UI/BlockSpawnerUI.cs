using UnityEngine;

public class BlockSpawnerUI : MonoBehaviour
{
    public GameObject blockPrefab;

    private void OnEnable()
    {
        BlockSpawner.OnSpawnBlock += HandleBlockSpawn;
    }

    private void OnDisable()
    {
        BlockSpawner.OnSpawnBlock -= HandleBlockSpawn;
    }

    private void HandleBlockSpawn(Vector3 position)
    {
        Instantiate(blockPrefab, position, Quaternion.identity);
    }
}
