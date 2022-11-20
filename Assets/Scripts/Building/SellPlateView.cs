using System;
using UnityEngine;
using UnityEngine.UI;

public class SellPlateView : MonoBehaviour
{
    [SerializeField] private Button _sellButton;

    private Action _sellButtonCallback;

    public void ShowAt(Vector3 position)
    {
        this.transform.position = position;
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void SetSellButtonCallback(Action callback)
    {
        _sellButtonCallback = callback;
    }

    private void SellButtonClickHandler()
    {
        _sellButtonCallback?.Invoke();
    }

    private void Start()
    {
        _sellButton.onClick.AddListener(SellButtonClickHandler);
    }

    private void OnDestroy()
    {
        _sellButton.onClick.RemoveListener(SellButtonClickHandler);
    }
}