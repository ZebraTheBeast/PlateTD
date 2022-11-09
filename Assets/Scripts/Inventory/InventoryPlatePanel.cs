using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PlateTD.Inventory
{
    public class InventoryPlatePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TextMeshProUGUI _amountText;
        [SerializeField] private Image _plateImage;

        private Action<Vector2> _beginDragCallback;
        private Action<Vector2> _endDragCallback;
        private Action<Vector2> _dragCallback;

        public void SetPlatePanel(
            int amount,
            Sprite plateSprite,
            Action<Vector2> beginDragCallback,
            Action<Vector2> endDragCallback,
            Action<Vector2> dragCallback)
        {
            _amountText.SetText($"{amount}");
            _plateImage.sprite = plateSprite;
            _beginDragCallback = beginDragCallback;
            _endDragCallback = endDragCallback;
            _dragCallback = dragCallback;
        }

        public void SetAmount(int amount)
        {
            _amountText.SetText(amount.ToString());
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _beginDragCallback?.Invoke(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _endDragCallback?.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _dragCallback?.Invoke(eventData.position);
        }
    }
}