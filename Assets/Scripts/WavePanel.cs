using PlateTD.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class WavePanel : MonoBehaviour
{
    [SerializeField] private Button _nextWaveButton;

    private void NextWaveButtonClickHandler()
    {
        GameEvents.InvokeStartWave();
    }

    private void Start()
    {
        _nextWaveButton.onClick.AddListener(NextWaveButtonClickHandler);
    }

    private void OnDestroy()
    {
        _nextWaveButton.onClick.RemoveListener(NextWaveButtonClickHandler);
    }
}