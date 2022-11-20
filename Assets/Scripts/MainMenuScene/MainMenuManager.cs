using PlateTD;
using PlateTD.Extensions;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;

    [SerializeField] private SettingsMenuView _settingsWindow;
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private LevelMenuWindow _levelMenuWindow;

    private MainMenuService _mainMenuService;
    private SettingsMenuService _settingsMenuService;
    private LevelMenuService _levelMenuService;

    private void LevelButtonClickHandler()
    {
        _mainMenuService.HideWindow();
        _levelMenuService.ShowWindow();
    }

    private void SettingsButtonClickHandler()
    {
        _mainMenuService.HideWindow();
        _settingsMenuService.ShowWindow();
    }

    private void CloseSettingsClickHandler()
    {
        _settingsMenuService.HideWindow();
        _mainMenuService.ShowWindow();
    }

    private void CloseLevelMenuClickHandler()
    {
        _levelMenuService.HideWindow();
        _mainMenuService.ShowWindow();
    }

    private void PrepareLevelMenuService()
    {
        var sceneLoadingService = ServiceLocator.Resolve<SceneLoadingService>();
        _levelMenuService = new LevelMenuService(_levelMenuWindow, sceneLoadingService);
    }

    private void Awake()
    {
        _mainMenuService = new MainMenuService(_mainMenuView);
        _settingsMenuService = new SettingsMenuService(_settingsWindow, _audioMixer);
    }

    private void Start()
    {
        PrepareLevelMenuService();

        _mainMenuService.SetSelectLevelButtonClickCallback(LevelButtonClickHandler);
        _mainMenuService.SetSettingsButtonClickCallback(SettingsButtonClickHandler);

        _settingsMenuService.SetCloseSettingsClickCallback(CloseSettingsClickHandler);
        _levelMenuService.SetCloseLevelMenuClickCallback(CloseLevelMenuClickHandler);
    }
}