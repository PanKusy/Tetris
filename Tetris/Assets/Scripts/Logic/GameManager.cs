using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    //-----------------------------

    public float fallSpeed = 1f;

    public int boardWidth = 10;
    public int boardHeight = 20;

    public Vector3 player1SpawnPoint = new Vector3(15, 18, 0);
    public Vector3 player2SpawnPoint = new Vector3(-15, 18, 0);


}