using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public Music[] musicArray;
    private string currentMusicID;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Music m in musicArray)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
            m.source.playOnAwake = false;
            
            if (m.musicID == "Lv_Main")
            {
                m.source.loop = true;
            }
        }
    }

    public void ChangeMusic(string newMusicID)
    {
        foreach (Music m in musicArray)
        {
            if (m.musicID == currentMusicID)
            {
                if (m.musicID == "Lv_Start" && newMusicID == "Lv_Main")
                {
                    break;
                }
                else
                {
                    m.source.Stop();
                    break;
                }
            }
        }

        currentMusicID = newMusicID;

        foreach (Music m in musicArray)
        {
            if (m.musicID == currentMusicID)
            {
                if (m.musicID == "Lv_Main")
                {
                    m.source.PlayDelayed(float.Parse("2.666667"));
                }
                else
                {
                    m.source.Play();
                }
                break;
            }
        }
    }
}
