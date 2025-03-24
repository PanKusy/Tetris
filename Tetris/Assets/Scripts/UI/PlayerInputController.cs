using UnityEngine;
using UnityEngine.InputSystem;

namespace GameUI
{
    public class PlayerInputController : MonoBehaviour
    {
        public Block currentBlock; // przypnij klocek w Inspectorze

        private float moveCooldown = 0.2f;
        private float moveTimer = 0f;

        private Vector2 moveInput;

        private void Update()
        {
            moveTimer += Time.deltaTime;

            if (moveInput.x != 0 && moveTimer >= moveCooldown)
            {
                TryMove((int)Mathf.Sign(moveInput.x));
                moveTimer = 0f;
            }
        }

        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        private void TryMove(int direction)
        {
            if (currentBlock == null) return;

            Vector3 move = new Vector3(direction, 0, 0);
            if (CanMove(move))
            {
                currentBlock.transform.position += move;
            }
        }

        private bool CanMove(Vector3 move)
        {
            foreach (Transform child in currentBlock.transform)
            {
                Vector2 newPos = GridManager.Round(child.position + move);

                if (!GridManager.InsideBorder(newPos)) return false;
                if (GridManager.IsOccupied(newPos)) return false;
            }
            return true;
        }
    }
}
