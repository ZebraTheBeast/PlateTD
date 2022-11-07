using UnityEngine;

namespace PlateTD.Utilities
{
    public static class Mouse3D
    {
        public static bool TryGetPosition(Vector3 position, int layerMask, out Vector3 hitPoint)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                hitPoint = hit.point;
                return true;
            }

            hitPoint = Vector3.zero;

            return false;
        }
    }
}