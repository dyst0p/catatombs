using CataTombs.Tiles;
using UnityEngine;

namespace CataTombs.Movement
{
    public class TileAligned : MonoBehaviour
    {
        public Tile tile { get; protected set; }

        private void Awake()
        {
            FindTile();
        }

        public void FindTile()
        {
            if (RaycastToTile.Raycast(transform.position + Vector3.up, Vector3.down, 2, transform, out RaycastHit hit))
                tile = hit.transform.GetComponent<Tile>();
            else
            {
                tile = null;
            }
        }
    }
}