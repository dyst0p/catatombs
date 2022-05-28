using CataTombs.Tiles;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace CataTombs.Movement
{
    public class AvatarMover : BaseMover, IStrafable
    {
        protected float walkInput;
        protected float turnInput;
        protected float strafeInput;
        protected override void Update()
        {
            if (walkInput > 0)
                GoForward();
            if (walkInput < 0)
                GoBackward();
            if (turnInput < 0)
                TurnLeft();
            if (turnInput > 0)
                TurnRight();
            if (strafeInput < 0)
                StrafeLeft();
            if (strafeInput > 0)
                StrafeRight();

            base.Update();
        }

        public void GetWalkInput(CallbackContext value) => walkInput = value.ReadValue<float>();
        public void GetTurnInput(CallbackContext value) => turnInput = value.ReadValue<float>();
        public void GetStrafeInput(CallbackContext value) => strafeInput = value.ReadValue<float>();

        public void StrafeLeft()
        {
            if (inMovement || inRotation)
                return;

            var direction = transform.forward;
            Quaternion rotation = Quaternion.Euler(0, -60, 0);
            direction = rotation * direction;
            if (RaycastToTile.Raycast(transform.position, direction, 2f, transform, out RaycastHit hit))
            {
                targetTile = hit.transform.GetComponent<Tile>();
                targetPosition = targetTile.transform.position;
                inMovement = true;
            }

            TurnRight();
        }

        public void StrafeRight()
        {
            if (inMovement || inRotation)
                return;

            var direction = transform.forward;
            Quaternion rotation = Quaternion.Euler(0, 60, 0);
            direction = rotation * direction;
            if (RaycastToTile.Raycast(transform.position, direction, 2f, transform, out RaycastHit hit))
            {
                targetTile = hit.transform.GetComponent<Tile>();
                targetPosition = targetTile.transform.position;
                inMovement = true;
            }

            TurnLeft();
        }
    }
}