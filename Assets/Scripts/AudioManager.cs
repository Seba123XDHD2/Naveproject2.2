using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public struct AudioClipStruct
{
  public  string audioId;
  public  AudioClip sfxClip;

}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    AudioSource audioSource;
    public bool changePitchOnPlay = true;
    public AudioClipStruct[] sfxList;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioSFX(string sfxName)
    {
        for (int i = 0; i < sfxList.Length; i++)
        {
            if(sfxList[i].audioId==sfxName)
            {
                if(changePitchOnPlay)
                audioSource.pitch = Random.Range(0.95f,1.1f);
                audioSource.PlayOneShot(sfxList[i].sfxClip);
                    return;

            }
        }
    }

}
