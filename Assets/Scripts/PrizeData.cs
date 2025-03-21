using UnityEngine;

namespace dev.xrlab.roulette
{
    [CreateAssetMenu(fileName = "NewPrize", menuName = "Roulette/Prize")]
    public class PrizeData : ScriptableObject
    {
        public string prizeName;
        public Sprite prizeSprite;
        [TextArea] public string prizeDescription;
    }
}
