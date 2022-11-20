using PlateTD.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace PlateTD.Waves
{
    public class WavePanel : MonoBehaviour
    {
        [SerializeField] private Button _nextWaveButton;

        private void NextWaveButtonClickHandler()
        {
            GameEvents.InvokeStartWave();
            _nextWaveButton.gameObject.SetActive(false);
        }

        private void EndWaveHandler(bool isLastWave)
        {
            _nextWaveButton.gameObject.SetActive(!isLastWave);
        }

        private void Start()
        {
            _nextWaveButton.onClick.AddListener(NextWaveButtonClickHandler);
            GameEvents.OnEndWave += EndWaveHandler;
        }

        private void OnDestroy()
        {
            _nextWaveButton.onClick.RemoveListener(NextWaveButtonClickHandler);
            GameEvents.OnEndWave -= EndWaveHandler;
        }
    }
}