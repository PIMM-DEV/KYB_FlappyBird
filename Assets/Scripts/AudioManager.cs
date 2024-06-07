using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public int channels;
    AudioSource[] sfxPlayers;
    public float sfxVolume;
    int channelIndex;

    public enum Sfx { BulletSound, CrushSound, GameOverSound, HeartSound, JumpSound };

   void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;

        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;
            {
                if (sfxPlayers[loopIndex].isPlaying)
                    continue;

                channelIndex = loopIndex;
                sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
                sfxPlayers[loopIndex].Play();
                DontDestroyOnLoad(transform.gameObject);
                break;
            }
        }
        

    }
}
