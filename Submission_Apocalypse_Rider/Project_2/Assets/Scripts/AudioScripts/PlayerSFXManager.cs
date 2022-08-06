using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    public PlayerSFX[] playerSFXArray;
    private string currentSfxID;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (PlayerSFX p in playerSFXArray)
        {
            p.source = gameObject.AddComponent<AudioSource>();
            p.source.clip = p.clip;
            p.source.playOnAwake = false;

            if (p.sfxID == "Player_Engine")
            {
                p.source.loop = true;
                p.source.volume = 0.5f;
            }
        }
    }

    public void PauseEngineSFX()
    {
        foreach (PlayerSFX p in playerSFXArray)
        {
            if (p.sfxID == "Player_Engine")
            {
                if (p.source.isPlaying == true)
                {
                    p.source.Stop();
                    break;
                }
            }
        }
    }

    public void PlayEngineSFX()
    {
        foreach (PlayerSFX p in playerSFXArray)
        {
            if (p.sfxID == "Player_Engine")
            {
                if (p.source.isPlaying == false)
                {
                    p.source.Play();
                    break;
                }
            }
        }
    }

    public void PlayShootingSFX()
    {
        foreach (PlayerSFX p in playerSFXArray)
        {
            if (p.sfxID == "Player_Shooting")
            {
                if (p.source.isPlaying == false)
                {
                    p.source.Play();
                    break;
                }
            }
        }
    }
}
