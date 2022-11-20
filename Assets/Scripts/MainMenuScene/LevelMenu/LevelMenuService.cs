using System;
using PlateTD;
using PlateTD.Extensions;
using UnityEngine;

public class LevelMenuService
{
    private LevelMenuWindow _levelMenuWindow;

    private SceneLoadingService _sceneLoadingService;

    public LevelMenuService(LevelMenuWindow levelMenuWindow, SceneLoadingService sceneLoadingService)
    {
        _levelMenuWindow = levelMenuWindow;
        _sceneLoadingService = sceneLoadingService;

        InitWindow();
    }

    private Action _closeLevelMenuClickCallback;

    public void ShowWindow()
    {
        _levelMenuWindow.SetLevels(_sceneLoadingService.Levels);
        _levelMenuWindow.SetActive(true);
    }

    public void HideWindow()
    {
        _levelMenuWindow.SetActive(false);
    }

    public void SetCloseLevelMenuClickCallback(Action callback)
    {
        _closeLevelMenuClickCallback?.Invoke();
    }

    private void LoadLevel(string name)
    {
        _sceneLoadingService.LoadLevel(name);
    }

    private void InitWindow()
    {
        _levelMenuWindow.SetLevelButtonClickCallback(LoadLevel);
    }
}