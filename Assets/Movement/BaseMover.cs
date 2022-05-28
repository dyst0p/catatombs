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
        protected bool inMovement;
        protected bool inRotation;

        protected Tile targetTile;
        protected Vector3 targetPosition;
        protected Quaternion targetRotation;

        public Tile tile => tileInfo?.tile;

        private void Awake()
        {
            tileInfo = GetComponent<TileAligned>();
            targetTile = tile;
        }

        protected virtual void Update()
        {
            if (inMovement)
            {
                if ((targetTile.unit != null && targetTile.unit != gameObject) || targetTile == null)
                {
                    targetTile = tile;
                    targetPosition = targetTile.transform.position;
                }
                
                transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                    movementSpeed * Time.deltaTime);
                float restDistance = Vector3.Distance(transform.position, targetPosition);
                if (restDistance <= distanseBetweenTiles / 2)
                {
                    tile.unit = null;
                    tileInfo.FindTile();
                    if (restDistance == 0)
                        inMovement = false;
                }
            }

            if (inRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
                if (Quaternion.Equals(transform.rotation, targetRotation))
                    inRotation = false;
            }
        }

        public void GoForward()
        {
            if (transform.position != targetTile.transform.position)
                return;

            if (RaycastToTile.Raycast(transform.position, transform.forward, 2f, transform, out RaycastHit hit))
            {
                targetTile = hit.transform.GetComponent<Tile>();
                targetPosition = targetTile.transform.position;
                inMovement = true;
            }
        }

        public void GoBackward()
        {
            if (inMovement)
                return;

            if (RaycastToTile.Raycast(transform.position, -transform.forward, 2f, transform, out RaycastHit hit))
            {
                targetTile = hit.transform.GetComponent<Tile>();
                targetPosition = targetTile.transform.position;
                inMovement = true;
            }
        }

        public void TurnLeft()
        {
            if (inRotation)
                return;

            var angle = Mathf.Round(transform.eulerAngles.y - 60);
            targetRotation = Quaternion.Euler(0, angle, 0);
            inRotation = true;
        }

        public void TurnRight()
        {
            if (inRotation)
                return;
            
            var angle = Mathf.Round(transform.eulerAngles.y + 60);
            targetRotation = Quaternion.Euler(0, angle, 0);
            inRotation = true;
        }
    }
}