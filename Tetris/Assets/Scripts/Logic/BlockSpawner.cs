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

    public static event Action<GameObject, Vector3> OnSpawnBlock;
    public void SpawnBlock()
    {
        int index = UnityEngine.Random.Range(0, block.Length);
        //GameObject newBlock = Instantiate(block[index], spawnPoint.position, Quaternion.identity);
        Vector3 spawnPoint = new Vector3(5, 18, 0);
        OnSpawnBlock?.Invoke(block[index], spawnPoint);
        //currentBlock = newBlock;

        //Block blockScript = newBlock.GetComponent<Block>();
        //blockScript.blockSpawner = this;


    }

    public void OnBlockLanded()
    {
        SpawnBlock();
    }


}
