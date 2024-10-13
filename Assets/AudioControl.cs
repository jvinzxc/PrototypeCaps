using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip ForestBackground;
    public AudioClip SniperShoot;
    public AudioClip InjectionHeal;
    public AudioClip NetGunPrototype;
    public AudioClip InjectionSound;

    private void Start()
    {
        musicSource.clip = ForestBackground;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
