using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlateTD.EndLevelService
{
    public class EndLevelView : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private TextMeshProUGUI _endLevelText;

        private Action _mainMenuButtonCallback;

        public void SetActive(bool state)
        {
            this.gameObject.SetActive(state);
        }

        public void SetText(string text)
        {
            _endLevelText.SetText(text);
        }

        public void SetMainMenuButtonCallback(Action callback)
        {
            _mainMenuButtonCallback = callback;
        }

        private void MainMenuButtonClickHandler()
        {
            _mainMenuButtonCallback?.Invoke();
        }

        private void Start()
        {
            _mainMenuButton.onClick.AddListener(MainMenuButtonClickHandler);
        }

        private void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveListener(MainMenuButtonClickHandler);
        }
    }
}
