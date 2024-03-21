using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundFXSource;

    [Space, Header("Pither's properties")]
    [SerializeField, Range(0, 3)] private float _minPitch;
    [SerializeField, Range(0, 3)] private float _maxPitch;
    public static AudioManager Instance;

    public const float _defaultPitch = 1f;

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
        _soundFXSource.pitch = _defaultPitch;
        _soundFXSource.PlayOneShot(clip);
    }

    public void PlayRandomPitchedSFX(AudioClip clip)
    {
        _soundFXSource.pitch = Random.Range(_minPitch, _maxPitch);
        _soundFXSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        _musicSource.Stop();
        _musicSource.clip = null;
        _musicSource.loop = false;
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicSource.UnPause();
    }
}
