using CataTombs.Tiles;
using UnityEngine;

namespace CataTombs.Movement
{
    public class StrafableMover : BaseMover, IStrafable
    {
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