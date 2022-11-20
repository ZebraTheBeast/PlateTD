using System;
using System.Collections.Generic;
using PlateTD.Entities;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuWindow : MonoBehaviour
{
    [SerializeField] private Transform _grid;
    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Button _backButton;

    private List<LevelButton> _levelButtons;

    private Action<string> _levelButtonClickCallback;
    private Action _backButtonClickCallback;

    public void SetActive(bool state)
    {
        this.gameObject.SetActive(state);
    }

    public void SetLevels(List<LevelData> levels)
    {
        ResetLevels();

        foreach (var level in levels)
        {
            var levelButton = Instantiate(_levelButtonPrefab, _grid);
            levelButton.SetLevelButton(level.Name);
            levelButton.SetLevelButtonClickCallback(() => LevelButtonClickHandler(level.Name));

            _levelButtons.Add(levelButton);
        }
    }

    public void SetLevelButtonClickCallback(Action<string> callback)
    {
        _levelButtonClickCallback = callback;
    }

    public void SetBackButtonClickCallback(Action callback)
    {
        _backButtonClickCallback = callback;
    }

    private void ResetLevels()
    {
        if (_levelButtons != null && _levelButtons.Count != 0)
        {
            foreach (var levelButton in _levelButtons)
            {
                Destroy(levelButton.gameObject);
            }
        }

        _levelButtons = new List<LevelButton>();
    }

    private void LevelButtonClickHandler(string levelName)
    {
        _levelButtonClickCallback?.Invoke(levelName);
    }

    private void BackButtonClickHandler()
    {
        _backButtonClickCallback?.Invoke();
    }

    private void Start()
    {
        _backButton.onClick.AddListener(BackButtonClickHandler);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(BackButtonClickHandler);
    }
}
