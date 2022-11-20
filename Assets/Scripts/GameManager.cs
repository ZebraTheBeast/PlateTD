using PlateTD;
using PlateTD.Extensions;
using PlateTD.SO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LevelsConfig _levelsConfig;
    private SceneLoadingService _sceneLoadingService;

    private void InitServices()
    {
        _sceneLoadingService = new SceneLoadingService(_levelsConfig.Levels);
        ServiceLocator.RegisterService<SceneLoadingService>(_sceneLoadingService);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            InitServices();
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
