using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip menuTrack;
    [SerializeField] AudioClip[] gameplayTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider musicVolumeSlider;
    bool menuTrackPlaying;
    bool gameplayTracksPlaying;

    public static MusicManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        musicVolumeSlider.value = 1f;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            if (!gameplayTracksPlaying)
            {
                StartCoroutine(playAudioSequentially());
                menuTrackPlaying = false;
            }
        }
        else if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level 1"))
            PlayMenuTrack();

        audioSource.volume = musicVolumeSlider.value;
    }

    IEnumerator playAudioSequentially()
    {
        gameplayTracksPlaying = true;
        audioSource.loop = false;
        for (int i = 0; i < gameplayTracks.Length; i++)
        {
            if (i == gameplayTracks.Length - 1) i = 0; //If the end of music sequence is reached, loop back to beginning of music sequence

            audioSource.clip = gameplayTracks[i];
            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }
    }

    void PlayMenuTrack()
    {
        if (!menuTrackPlaying)
        {
            menuTrackPlaying = true;
            audioSource.clip = menuTrack;
            audioSource.loop = true;
            audioSource.Play();
            gameplayTracksPlaying = false;
        }
    }
}
