using System;
using UnityEngine;

public class MainMenuService
{
    private MainMenuView _mainMenuView;

    public MainMenuService(MainMenuView mainMenuView)
    {
        _mainMenuView = mainMenuView;

        InitView();
    }

    private Action _selectLevelButtonClickCallback;
    private Action _settingsButtonClickCallback;

    public void ShowWindow()
    {
        _mainMenuView.gameObject.SetActive(true);
    }

    public void HideWindow()
    {
        _mainMenuView.gameObject.SetActive(false);
    }

    public void SetSelectLevelButtonClickCallback(Action callback)
    {
        _selectLevelButtonClickCallback = callback;
    }

    public void SetSettingsButtonClickCallback(Action callback)
    {
        _settingsButtonClickCallback = callback;
    }

    private void SelectLevelButtonClickHanlder()
    {
        _selectLevelButtonClickCallback?.Invoke();
    }

    private void SettingsButtonClickHandler()
    {
        _settingsButtonClickCallback?.Invoke();
    }

    private void QuitButtonHandler()
    {
        Application.Quit();
    }

    private void InitView()
    {
        _mainMenuView.SetSelectLevelButtonCallback(SelectLevelButtonClickHanlder);
        _mainMenuView.SetSettingsButtonCallback(SettingsButtonClickHandler);
        _mainMenuView.SetQuitButtonCallback(QuitButtonHandler);
    }

}