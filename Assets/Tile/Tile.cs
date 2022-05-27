using UnityEngine;

namespace CataTombs.Tiles
{
    public class Tile : MonoBehaviour
    {
        public GameObject unit;
        public bool IsEmpty => unit == null;
    }
}