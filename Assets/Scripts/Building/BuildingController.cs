using UnityEngine;
using PlateTD.Utilities;
using UnityEngine.EventSystems;
using System;

namespace PlateTD.Building
{
    public class BuildingController : MonoBehaviour, IPointerClickHandler
    {
        private LayerMask _fieldLayerMask;

        public event Action<Vector3> OnFieldClick;
        public event Action OnFieldMissClick;

        public void SetFieldLayerMask(LayerMask layerMask)
        {
            _fieldLayerMask = layerMask;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Mouse3D.TryGetPosition(eventData.position, _fieldLayerMask, out Vector3 clickPosition))
            {
                OnFieldClick?.Invoke(clickPosition);
            }
            else
            {
                OnFieldMissClick?.Invoke();
            }
        }
    }
}
