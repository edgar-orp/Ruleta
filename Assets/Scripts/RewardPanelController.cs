using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace dev.xrlab.roulette
{
    public class RewardPanelController : MonoBehaviour
    {
        public GameObject panel;
        public TMP_Text prizeNameText;
        public Image prizeImage;
        public TMP_Text prizeDescriptionText;

        public void ShowPrize(PrizeData prizeData)
        {
            if (prizeData == null) return;

            prizeNameText.text = prizeData.prizeName;
            prizeImage.sprite = prizeData.prizeSprite;
            prizeDescriptionText.text = prizeData.prizeDescription;

            panel.SetActive(true);

            AudioManager.Instance.PlaySound(AudioManager.Instance.panelOpenSound);
        }

        public void HidePanel()
        {
            panel.SetActive(false);

            AudioManager.Instance.PlaySound(AudioManager.Instance.panelCloseSound);
        }
    }
}
