using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySounds : MonoBehaviour
{

    private AudioSource aSource;


    [SerializeField] private AudioClip ButtonTep, GameOverS,AnimyBullet,PlayerBullet;

    public static MySounds Instance;
    float jumpPich = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }

    }

    private void Start()
    {
        aSource = this.gameObject.AddComponent<AudioSource>();
        aSource.playOnAwake = false;
        aSource.loop = false;



    }

    private void playClip(AudioClip clip, float volume, float jumpPich)
    {
        if (PlayerPrefs.GetInt("SoundPref") == 0)
        {
            if (aSource.isPlaying == true)
            {

                GameObject tempObj = new GameObject();
                tempObj.transform.SetParent(transform);
                AudioSource tempSource = tempObj.AddComponent<AudioSource>();
                tempSource.playOnAwake = false;
                tempSource.loop = false;
                tempSource.volume = volume;
                tempSource.clip = clip;
                tempSource.pitch = jumpPich;
                tempSource.Play();
                Destroy(tempObj, tempSource.clip.length);
            }
            else
            {
                aSource.pitch = jumpPich;

                aSource.clip = clip;
                aSource.volume = volume;
                aSource.Play();
                Debug.Log(jumpPich);
            }
        }
    }


    public void OnGameSound()
    {

        if (PlayerPrefs.GetInt("SoundPref") == 0)
        {
            PlayerPrefs.SetInt("SoundPref", 1);

        }
        else
        {


            PlayerPrefs.SetInt("SoundPref", 0);

        }

    }

    public void OnGameOverS()
    {
        playClip(GameOverS, 1f, 1f);
    }

    public void OnButtonTap()
    {
        // VibrationManager.Instance.FirstLite();
        playClip(ButtonTep, 1f, 1f);
    }
     public void OnAnimyBullet()
    {
        // VibrationManager.Instance.FirstLite();
        playClip(AnimyBullet, 0.1f, 1f);
    } public void OnPlayerBullet()
    {
        // VibrationManager.Instance.FirstLite();
        playClip(PlayerBullet, 0.5f, 1f);
    }

}
