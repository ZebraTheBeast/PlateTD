using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _levelButton;
    [SerializeField] private TextMeshProUGUI _text;

    private Action _levelButtonClickCallback;

    public void SetLevelButton(string levelName)
    {
        _text.SetText(levelName);
    }

    public void SetLevelButtonClickCallback(Action callback)
    {
        _levelButtonClickCallback = callback;
    }

    private void OnLevelButtonClickHandler()
    {
        _levelButtonClickCallback?.Invoke();
    }

    private void Awake()
    {
        _levelButton.onClick.AddListener(OnLevelButtonClickHandler);
    }

    private void OnDestroy()
    {
        _levelButton.onClick.RemoveListener(OnLevelButtonClickHandler);
    }

}