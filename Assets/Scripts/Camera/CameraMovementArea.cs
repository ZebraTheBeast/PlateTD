using UnityEngine;
using UnityEngine.EventSystems;

namespace PlateTD.CameraTD
{
    public class CameraMovementArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public bool IsDrag { get; private set; }
        public float Value { get; private set; }

        private Vector3 _startValue;

        private void Awake()
        {
            IsDrag = false;
            Value = 0;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDrag = true;
            _startValue = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Value = eventData.position.y - _startValue.y;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsDrag = false;
        }
    }
}