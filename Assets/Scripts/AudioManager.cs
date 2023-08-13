using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sound;
    public Button soundButton;
    public Sprite soundOnImage;
    public Sprite soundOffImage;

    private bool isOnSound = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        UpdateSoundButtonImage();
    }

    private void UpdateSoundButtonImage()
    {
        soundButton.image.sprite = isOnSound ? soundOnImage : soundOffImage;
    }

    public void AudioControlSound()
    {
        isOnSound = !isOnSound;
        sound.mute = !isOnSound;
        UpdateSoundButtonImage();
    }
}
