using PlateTD.Extensions;

namespace PlateTD.EndLevelService
{
    public class EndLevelService
    {
        private const string WinText = "Congratulation!\nYou won!";
        private const string LostText = "Congratulation!\nYou Lost!";

        private EndLevelView _endLevelView;
        private SceneLoadingService _sceneLoadingService;

        public EndLevelService(EndLevelView endLevelView)
        {
            _endLevelView = endLevelView;
            _sceneLoadingService = ServiceLocator.Resolve<SceneLoadingService>();
            _endLevelView.SetMainMenuButtonCallback(LoadMainMenuScene);
        }

        public void ShowWinView()
        {
            _endLevelView.SetText(WinText);
            _endLevelView.SetActive(true);
        }

        public void ShowLostView()
        {
            _endLevelView.SetText(LostText);
            _endLevelView.SetActive(true);
        }

        private void LoadMainMenuScene()
        {
            _sceneLoadingService.LoadMainMenu();
        }
    }
}