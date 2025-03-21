using UnityEngine;
using UnityEngine.UI;

namespace dev.xrlab.roulette
{
    public class PrizeItem : MonoBehaviour
    {
        public PrizeData prizeData;
        private Image prizeImage;

        private void Awake()
        {
            prizeImage = GetComponent<Image>();
            AssignPrizeImage();
        }

        private void AssignPrizeImage()
        {
            if (prizeData != null)
            {
                prizeImage.sprite = prizeData.prizeSprite;
            }
        }
    }
}
