using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerComponent : MonoBehaviour
{
    

    public void PlaySoundOnManager(string SoundId)
    {
        AudioManager.Instance?.PlayAudioSFX(SoundId);

    }
}
