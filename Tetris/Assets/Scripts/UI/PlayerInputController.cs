using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction moveAction;

    private GameObject activePiece;

    private float moveCooldown = 0.1f;
    private float lastMoveTime;

    private void Awake()
    {
        var map = inputActions.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        moveAction.Enable();
    }
    private void OnEnable()
    {
        EventManager.instance.onBlockSpawned += SetActivePiece;
    }
    private void OnDisable()
    {
        EventManager.instance.onBlockSpawned -= SetActivePiece;
    }

    public void SetActivePiece(GameObject piece)
    {
        activePiece = piece;
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

            if (!GridManager.InsideBorder(newPosition) || GridManager.IsOccupied(newPosition))
            {
                return false;
            }
        }

        return true;
    }
}
