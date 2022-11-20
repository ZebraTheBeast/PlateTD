using System.Collections.Generic;
using PlateTD.Entities;
using UnityEngine.SceneManagement;

namespace PlateTD
{
    public class SceneLoadingService
    {
        private const string MainMenuSceneName = "MainMenu";

        public SceneLoadingService(List<LevelData> levels)
        {
            Levels = levels;
        }

        public List<LevelData> Levels { get; private set; }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
        }

    }
}
