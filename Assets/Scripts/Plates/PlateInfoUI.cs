using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlateTD.Plates
{
    public class PlateInfoUI : MonoBehaviour
    {
        [SerializeField] private Image _reloadImage;
        [SerializeField] private TextMeshProUGUI _upgradeText;

        public void SetUpgradedPlateText(int consumedPlates, int platesToUpgrade)
        {
            if (platesToUpgrade != 0)
            {
                _upgradeText.SetText($"{consumedPlates} / {platesToUpgrade}");
            }
            else
            {
                _upgradeText.gameObject.SetActive(false);
            }
        }

        public void SetReloadImagePercentage(float fillAmount)
        {
            _reloadImage.fillAmount = fillAmount;
        }
    }
}
