using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource clickSource;
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private AudioClip clickClip;

    public static AudioManager Instance { get; private set; }

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

    void Start()
    {
        clickSource.clip = clickClip;
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    

    public void PlayAudio()
    {
        clickSource.Play();
    }

}
