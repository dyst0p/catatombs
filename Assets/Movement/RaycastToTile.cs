using UnityEngine;

namespace CataTombs.Movement
{
    public class RaycastToTile
    {
        public static bool Raycast(Vector3 pos, Vector3 dir, float length, Transform caster, out RaycastHit hit)
        {
            hit = new RaycastHit();
            var layerMask = LayerMask.GetMask("Tile");
            var hits = Physics.RaycastAll(pos, dir, length, layerMask);
            foreach (RaycastHit rayHit in hits)
                if (rayHit.transform != caster)
                {
                    hit = rayHit;
                    return true;
                }
            return false;
        }
    }
}