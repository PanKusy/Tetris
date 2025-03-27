using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    //-------------------------------------


    public event Action onReachedEnd;
    public void ReachedEnd()
    {
        onReachedEnd?.Invoke();
    }

    public event Action<GameObject> onBlockSpawned;
    public void BlockSpawned(GameObject gameObject)
    {
        onBlockSpawned?.Invoke(gameObject);
    }
}
