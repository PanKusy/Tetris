using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction moveAction;
    private GridManager gridManager;
    public Player player;

    private GameObject activePiece;

    private float moveCooldown = 0.1f;
    private float lastMoveTime;

    private void Awake()
    {
        if (player == Player.player1)
        {
            var map = inputActions.FindActionMap("Player");
            moveAction = map.FindAction("Move");
        }
        else
        {
            var map = inputActions.FindActionMap("Player2");
            moveAction = map.FindAction("Move");
        }
        moveAction.Enable();
    }

    private void OnEnable()
    {
        EventManager.instance.onBlockSpawned += SetActivePiece;
        EventManager.instance.onAssignGridManager += SetGridManager;
    }
    private void OnDisable()
    {
        EventManager.instance.onBlockSpawned -= SetActivePiece;
        EventManager.instance.onAssignGridManager -= SetGridManager;
    }

    private void SetGridManager(GridManager gridManager, Player player)
    {
        if (this.player == player)
            this.gridManager = gridManager;
    }

    public void SetActivePiece(GameObject piece, Player player)
    {
        if (this.player == player)
            activePiece = piece;

        //if (gridManager == null)
        //    gridManager = activePiece.GetComponent<GridManager>();
    }

    private void Update()
    {
        if (activePiece == null) return;

        float moveInput = moveAction.ReadValue<Vector2>().x;

        if (Mathf.Abs(moveInput) > 0.1f && Time.time - lastMoveTime > moveCooldown)
        {
            Vector3 direction = Vector3.right * Mathf.Sign(moveInput);
            
            if (CanMove(direction))
            {
                activePiece.transform.position += direction;
                lastMoveTime = Time.time;
            }
        }
    }

    private bool CanMove(Vector3 direction)
    {
        foreach (Transform block in activePiece.transform)
        {
            Vector3 newPosition = block.position + direction;

            if (!gridManager.InsideBorder(newPosition) || gridManager.IsOccupied(newPosition))
            {
                return false;
            }
        }

        return true;
    }
}
