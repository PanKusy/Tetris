using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;

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
}