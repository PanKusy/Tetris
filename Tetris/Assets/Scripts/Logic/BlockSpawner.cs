using System;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] block;
    public Transform spawnPoint;
    private GameObject currentBlock;


    private void Start()
    {
        SpawnBlock();
    }

    public static event Action<Vector3> OnSpawnBlock;
    public void SpawnBlock()
    {
        int index = UnityEngine.Random.Range(0, block.Length);
        GameObject newBlock = Instantiate(block[index], spawnPoint.position, Quaternion.identity);
        currentBlock = newBlock;

        Block blockScript = newBlock.GetComponent<Block>();
        blockScript.blockSpawner = this;
    }

    public void OnBlockLanded()
    {
        SpawnBlock();
    }


}
