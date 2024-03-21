using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundFXSource;

    [Space, Header("Pith properties")]
    [SerializeField, Range(0, 3)] private float _minPitch;
    [SerializeField, Range(0, 3)] private float _maxPitch;
    public static AudioManager Instance;

    private const float _defaultPitch = 1f;

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

    public void StopMusic()
    {
        _musicSource.clip = null;
        _musicSource.loop = false;
        _musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        _soundFXSource.pitch = _defaultPitch;
        _soundFXSource.PlayOneShot(clip);
    }

    public void PlayRandomPitchedSFX(AudioClip clip)
    {
        _soundFXSource.pitch = Random.Range(_minPitch, _minPitch);
        _soundFXSource.PlayOneShot(clip);
    }
}
