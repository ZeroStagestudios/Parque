using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource Musica;
    public AudioSource sfxUI;
    public AudioSource ambiente;
    float musicaVolume = 1f;
    float sfxVolume = 1f;   
    float ambienteVolume = 1f;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        musicaVolume = PlayerPrefs.GetFloat("MusicaVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);  
        ambienteVolume = PlayerPrefs.GetFloat("AmbienteVolume", 1f);

        musicaVolume = Mathf.Clamp01(musicaVolume);
        sfxVolume = Mathf.Clamp01(sfxVolume);
        ambienteVolume = Mathf.Clamp01(ambienteVolume);

        Musica.volume = musicaVolume;
        sfxUI.volume = sfxVolume;
        ambiente.volume = ambienteVolume;
    }

    public void SetMusicaVolume(float volume)
    {
        musicaVolume = Mathf.Clamp01(volume);
        Musica.volume = musicaVolume;
        PlayerPrefs.SetFloat("MusicaVolume", musicaVolume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        sfxUI.volume = sfxVolume;
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
    public void SetAmbienteVolume(float volume)
    {
        ambienteVolume = Mathf.Clamp01(volume);
        ambiente.volume = ambienteVolume;
        PlayerPrefs.SetFloat("AmbienteVolume", ambienteVolume);
    }
    public void PlayMusica(AudioClip clip)
    {
        if (Musica.clip == clip && Musica.isPlaying)return;
        Musica.clip = clip;
        Musica.Play();
    }
    public void PlayAmbiente(AudioClip clip)
    {
        ambiente.PlayOneShot(clip);
    }
   public void PlaySFX(AudioClip clip)
{
    if (clip == null) return;
    Debug.Log("sfxUI: " + sfxUI);
    sfxUI.PlayOneShot(clip);
}
}
