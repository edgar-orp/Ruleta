using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace dev.xrlab.roulette
{
    public class DragRoulette : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public RectTransform roulette;
        public PrizeDetection prizeDetection; // Reference to PrizeDetection script

        private float angularVelocity = 0f;
        private float friction = 0.99f; // Friction factor
        private bool isSpinning = false; // Track if the roulette is still moving
        private bool prizeDetected = false; // Ensure we detect the prize only once

        public void OnDrag(PointerEventData eventData)
        {
            if (prizeDetected) prizeDetected = false; // Reset prize detection if user drags again

            float deltaAngle = -eventData.delta.x;
            roulette.Rotate(0, 0, -deltaAngle);
            angularVelocity = -deltaAngle; // Set velocity based on last drag
            isSpinning = true;

            AudioManager.Instance.PlaySound(AudioManager.Instance.spinSound);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isSpinning) return; // Prevent starting the coroutine multiple times
            StartCoroutine(ApplyInertia());
        }

        private IEnumerator ApplyInertia()
        {
            while (Mathf.Abs(angularVelocity) > 0.1f)
            {
                roulette.Rotate(0, 0, angularVelocity);
                angularVelocity *= friction; // Reduce speed gradually
                yield return null;
            }

            isSpinning = false;

            if (!prizeDetected) // Ensure prize is detected only once
            {
                prizeDetected = true;
                prizeDetection.DetectPrize();
            }
        }
    }
}
