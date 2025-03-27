using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] block;
    public Transform spawnPoint;
    private Scene scene;


    private void Awake()
    {
        scene = SceneManager.GetSceneByName("UIScene");
    }

    private void Start()
    {
        SpawnBlock();
    }

    private void OnEnable()
    {
        if (EventManager.instance != null)
            EventManager.instance.onReachedEnd += SpawnBlock;
    }
    private void OnDisable()
    {
        EventManager.instance.onReachedEnd -= SpawnBlock;
    }

    public void SpawnBlock()
    {
        int index = UnityEngine.Random.Range(0, block.Length);
        Vector3 spawnPoint = new Vector3(Settings.instance.boardWidth / 2, Settings.instance.boardHeight - 2, 0);
        GameObject newBlock = Instantiate(block[index], spawnPoint, Quaternion.identity);
        EventManager.instance.BlockSpawned(newBlock);

        SceneManager.MoveGameObjectToScene(newBlock, scene);
    }
}
