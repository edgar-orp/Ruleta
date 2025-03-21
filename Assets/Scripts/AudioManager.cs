using UnityEngine;

namespace dev.xrlab.roulette
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Sources")]
        public AudioSource sfxSource;

        [Header("Sound Clips")]
        public AudioClip spinSound;
        public AudioClip prizeDetectedSound;
        public AudioClip panelOpenSound;
        public AudioClip panelCloseSound;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            if (clip != null && sfxSource != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }
    }
}
