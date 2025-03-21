using UnityEngine;

namespace dev.xrlab.roulette
{
    public class PrizeDetection : MonoBehaviour
    {
        public PrizeItem[] prizes;
        public Transform arrow;
        public RewardPanelController rewardPanel;

        public void DetectPrize()
        {
            float rouletteAngle = transform.eulerAngles.z;
            float anglePerPrize = 360f / prizes.Length;
            int prizeIndex = Mathf.FloorToInt((rouletteAngle + (anglePerPrize / 2f)) % 360 / anglePerPrize);

            PrizeItem selectedPrize = prizes[prizeIndex];
            var data = selectedPrize.prizeData;

            Debug.Log($"You won: {data.prizeName}!");

            AudioManager.Instance.PlaySound(AudioManager.Instance.prizeDetectedSound);

            rewardPanel.ShowPrize(data);
        }
    }
}
