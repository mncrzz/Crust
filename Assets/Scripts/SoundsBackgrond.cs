using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SoundsBackground : MonoBehaviour
{
    public static SoundsBackground Instance;

    public List<AudioClip> lobbyClips;
    public List<AudioClip> gameClips;

    private AudioSource audioSource;
    private int lastLobbyIndex = -1;
    private int lastGameIndex = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioSource();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSource()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = false;
    }

    private void Start()
    {
        PlayMusicForCurrentScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }

    private void PlayMusicForCurrentScene()
    {
        StopAllCoroutines();
        
        string sceneName = SceneManager.GetActiveScene().name;
        List<AudioClip> currentClips = GetCurrentClipList(sceneName);

        if (currentClips == null || currentClips.Count == 0)
        {
            if (audioSource.isPlaying) audioSource.Stop();
            return;
        }

        PlayNewTrack(currentClips, sceneName);
    }

    private List<AudioClip> GetCurrentClipList(string sceneName)
    {
        return sceneName switch
        {
            "Lobby" => lobbyClips,
            "Game" => gameClips,
            _ => null
        };
    }

    private void PlayNewTrack(List<AudioClip> clips, string sceneName)
    {
        int newIndex = GetRandomClipIndex(clips, sceneName);
        if (newIndex == -1) return;

        UpdateLastIndex(sceneName, newIndex);
        StartCoroutine(PlayTrack(clips[newIndex]));
    }

    private int GetRandomClipIndex(List<AudioClip> clips, string sceneName)
    {
        if (clips.Count == 0) return -1;
        if (clips.Count == 1) return 0;

        int lastIndex = sceneName == "Lobby" ? lastLobbyIndex : lastGameIndex;
        int newIndex;

        do
        {
            newIndex = Random.Range(0, clips.Count);
        } while (newIndex == lastIndex);

        return newIndex;
    }

    private void UpdateLastIndex(string sceneName, int newIndex)
    {
        if (sceneName == "Lobby")
            lastLobbyIndex = newIndex;
        else if (sceneName == "Game")
            lastGameIndex = newIndex;
    }

    private IEnumerator PlayTrack(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        PlayMusicForCurrentScene();
    }
}
