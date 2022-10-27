using UnityEngine;

namespace PlateTD.Utilities
{
    public static class Mouse3D
    {
        public static Vector3 GetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
            return Vector3.zero;
        }

        public static Vector3 GetPosition(int layerMask)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                return hit.point;
            }
            return Vector3.zero;
        }
    }
}