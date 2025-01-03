using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    [SerializeField] private AudioSource BGM, DoorOpenSFX, ExplosionSFX, ShootSFX;
    void Awake()
    {
        if (AudioManager.audioManager != null && AudioManager.audioManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.audioManager = this;
            DontDestroyOnLoad(gameObject);
            BGM.Play();
        }


    }

    public void PlayDoor()
    {
        DoorOpenSFX.Play();
    }

    public void PlayBoom()
    {
        ExplosionSFX.Play();
    }

    public void PlayShoot()
    {
        ShootSFX.Play();
    }
}
