using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip defaultAmbienceSound;

    private AudioSource track01, track02;
    private bool isPlayingTrack01;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        isPlayingTrack01 = true;

        SwapTrack(defaultAmbienceSound);
    }
    
    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();
        StartCoroutine(FadeTrack(newClip));
        isPlayingTrack01 = !isPlayingTrack01;
    }

    public void ReturnToDefaultAmbienceSound()
    {
        SwapTrack(defaultAmbienceSound);
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.75f;
        float timeElapsed = 0f;
        if (isPlayingTrack01)
        {
            track02.clip = newClip;
            track02.loop = true;
            track02.Play();
            track02.volume = 0.5f;
            
            while(timeElapsed < timeToFade)
            {
                track01.volume = Mathf.Lerp(0.5f, 0f, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(0f, 0.5f, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track01.Stop();
        }
        else
        {
            track01.clip = newClip;
            track01.loop = true;
            track01.Play();
            track01.volume = 0.5f;
            while (timeElapsed < timeToFade)
            {
                track01.volume = Mathf.Lerp(0f, 0.5f, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(0.5f, 0f, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track02.Stop();
        }
    }
}
