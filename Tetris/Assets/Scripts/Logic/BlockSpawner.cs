using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] block;
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetSceneByName("UIScene");
    }

    public void SpawnBlock(Vector3 spawnPoint, Player player, GridManager gridManager)
    {
        int index = UnityEngine.Random.Range(0, block.Length);

        if (!gridManager.IsOccupied(spawnPoint))
        {
            GameObject newBlock = Instantiate(block[index], spawnPoint, Quaternion.identity);
            Block blockScript = newBlock.GetComponent<Block>();
            if (blockScript != null)
            {
                blockScript.player = player;
                blockScript.gridManager = gridManager;
            }
            EventManager.instance.BlockSpawned(newBlock, player);
            SceneManager.MoveGameObjectToScene(newBlock, scene);
        }
    }
}
