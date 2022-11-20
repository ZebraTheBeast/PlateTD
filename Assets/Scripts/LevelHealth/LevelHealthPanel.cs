using PlateTD.Extensions;
using TMPro;
using UnityEngine;

namespace PlateTD.LevelHealth
{
    public class LevelHealthPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        private LevelHealthService _levelHealthService;

        private void LevelHealthChangedHandler(int healthAmount)
        {
            _healthText.SetText($"{healthAmount}");
        }

        private void Start()
        {
            _levelHealthService = ServiceLocator.Resolve<LevelHealthService>();

            _levelHealthService.OnHealthChanged += LevelHealthChangedHandler;
        }

        private void OnDestroy()
        {
            _levelHealthService.OnHealthChanged -= LevelHealthChangedHandler;
        }
    }
}