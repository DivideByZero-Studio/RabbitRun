using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundFXSource;

    public static AudioManager Instance;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _soundFXSource.PlayOneShot(clip);
    }
}
