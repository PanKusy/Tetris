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


    public event Action<Player> onReachedEnd;
    public void ReachedEnd(Player player)
    {
        onReachedEnd?.Invoke(player);
    }

    public event Action<GameObject, Player> onBlockSpawned;
    public void BlockSpawned(GameObject gameObject, Player player)
    {
        onBlockSpawned?.Invoke(gameObject, player);
    }

    public event Action<GridManager, Player> onAssignGridManager;
    public void AssignGridManager(GridManager gridManager, Player player)
    {
        onAssignGridManager?.Invoke(gridManager, player);
    }

    public event Action<Player> onLineCleared;
    public void LineCleared(Player player)
    {
        onLineCleared?.Invoke(player);
    }
}
