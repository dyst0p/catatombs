using UnityEngine;
using CataTombs.Tiles;

namespace CataTombs.Movement
{
    public class BaseMover : MonoBehaviour, IWalkable, IRotatable
    {
        protected const float distanseBetweenTiles = 1.732f;
        protected TileAligned tileInfo;

        [SerializeField] protected float rotationSpeed;
        [SerializeField] protected float movementSpeed;

        protected Tile targetTile;
        protected Vector3 forwardTarget;

        public Tile tile => tileInfo?.tile;

        private void Awake()
        {
            tileInfo = GetComponent<TileAligned>();
            forwardTarget = transform.forward;
            targetTile = tile;
        }

        protected virtual void Update()
        {
            if ((targetTile.unit != gameObject && targetTile.unit != null) || targetTile == null)
                targetTile = tile;

            if (transform.position != targetTile.transform.position)
            {
                var targetPosition = targetTile.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                    movementSpeed * Time.deltaTime);
                float restDistance = Vector3.Distance(transform.position, targetPosition);
                if (restDistance <= distanseBetweenTiles / 2)
                {
                    tile.unit = null;
                    tileInfo.FindTile();
                    if (restDistance < 0.001f)
                    {
                        transform.position = targetTile.transform.position;
                    }
                }
            }

            if (transform.forward != forwardTarget)
            {
                transform.forward = Vector3.RotateTowards(transform.forward, forwardTarget,
                    rotationSpeed * Time.deltaTime, 0);
                if (Vector3.Angle(transform.forward, forwardTarget) < 0.1f)
                    transform.forward = forwardTarget;
            }
        }

        public void GoForward()
        {
            if (transform.position != targetTile.transform.position)
                return;

            if (RaycastToTile.Raycast(transform.position, transform.forward, 2f, transform, out RaycastHit hit))
                targetTile = hit.transform.GetComponent<Tile>();
        }

        public void GoBackward()
        {
            if (transform.position != targetTile.transform.position)
                return;

            if (RaycastToTile.Raycast(transform.position, -transform.forward, 2f, transform, out RaycastHit hit))
                targetTile = hit.transform.GetComponent<Tile>();
        }

        public void TurnLeft()
        {
            if (transform.forward != forwardTarget)
                return;

            Quaternion rotation = Quaternion.Euler(0, -60, 0);
            forwardTarget = rotation * forwardTarget;
        }

        public void TurnRight()
        {
            if (transform.forward != forwardTarget)
                return;

            Quaternion rotation = Quaternion.Euler(0, 60, 0);
            forwardTarget = rotation * forwardTarget;
        }
    }
}