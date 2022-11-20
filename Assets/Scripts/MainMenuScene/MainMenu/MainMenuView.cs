using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _selectLevelButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;

    private Action _selectLevelButtonCallback;
    private Action _settingsButtonCallback;
    private Action _quitButtonCallback;

    public void SetSelectLevelButtonCallback(Action callback)
    {
        _selectLevelButtonCallback = callback;
    }

    public void SetSettingsButtonCallback(Action callback)
    {
        _settingsButtonCallback = callback;
    }

    public void SetQuitButtonCallback(Action callback)
    {
        _quitButtonCallback = callback;
    }

    private void SelectLevelButtonHandler()
    {
        _selectLevelButtonCallback?.Invoke();
    }

    private void SettingsButtonHandler()
    {
        _settingsButtonCallback?.Invoke();
    }

    private void QuitButtonHandler()
    {
        _quitButtonCallback?.Invoke();
    }

    private void Start()
    {
        _selectLevelButton.onClick.AddListener(SelectLevelButtonHandler);
        _settingsButton.onClick.AddListener(SettingsButtonHandler);
        _quitButton.onClick.AddListener(QuitButtonHandler);
    }

    private void OnDestroy()
    {
        _selectLevelButton.onClick.RemoveListener(SelectLevelButtonHandler);
        _settingsButton.onClick.RemoveListener(SettingsButtonHandler);
        _quitButton.onClick.RemoveListener(QuitButtonHandler);
    }
}
