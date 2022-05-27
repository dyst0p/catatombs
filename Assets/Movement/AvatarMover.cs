using CataTombs.Tiles;
using UnityEngine;

namespace CataTombs.Movement
{
    public class AvatarMover : BaseMover, IStrafable
    {
        protected override void Update()
        {
            if (Input.GetKey(KeyCode.W))
                GoForward();
            if (Input.GetKey(KeyCode.S))
                GoBackward();
            if (Input.GetKey(KeyCode.A))
                TurnLeft();
            if (Input.GetKey(KeyCode.D))
                TurnRight();
            if (Input.GetKey(KeyCode.Q))
                StrafeLeft();
            if (Input.GetKey(KeyCode.E))
                StrafeRight();

            base.Update();
        }

        private void TeleportForward()
        {
            Debug.Log("Start teleport");
            var direction = transform.forward;
            var hits = Physics.RaycastAll(transform.position, direction, 2f);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log($"Start collider {hit.transform}");
                if (hit.transform.gameObject != gameObject)
                {
                    transform.position = hit.transform.position;
                    Debug.Log($"Collided with {hit.transform}");
                    return;
                }
            }
        }

        public void StrafeLeft()
        {
            if (transform.position != targetTile.transform.position || transform.forward != forwardTarget)
                return;

            var direction = transform.forward;
            Quaternion rotation = Quaternion.Euler(0, -60, 0);
            direction = rotation * direction;
            if (RaycastToTile.Raycast(transform.position, transform.forward, 2f, transform, out RaycastHit hit))
                targetTile = hit.transform.GetComponent<Tile>();

            if (targetTile == null)
                return;
            TurnRight();
        }

        public void StrafeRight()
        {
            if (transform.position != targetTile.transform.position || transform.forward != forwardTarget)
                return;

            var direction = transform.forward;
            Quaternion rotation = Quaternion.Euler(0, 60, 0);
            direction = rotation * direction;
            if (RaycastToTile.Raycast(transform.position, transform.forward, 2f, transform, out RaycastHit hit))
                targetTile = hit.transform.GetComponent<Tile>();

            if (targetTile == null)
                return;
            TurnLeft();
        }
    }
}