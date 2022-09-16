using System;
using SUPERCharacter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip jumpSound,shoootSound,dyingSound,doorOpenSound,buttonClickSound,loseMusic,victoryMusic;
    [SerializeField] private Image HPImage,timerImage;

    [SerializeField] private float timer = 60f;
    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerImage.fillAmount = timer / 60 ;
    }

    private void OnEnable()
    {
        SUPERCharacterAIO.JumpHappend += PlayJumpSound;
        GameStatusMenu.canvasIDevent += ShowCanvas;
        CheckList.DoorUnlock += PlayDoorOpen;
    }

    private void ShowCanvas(int canvasID)
    {
        if(canvasID == 1)
            _audioSource.PlayOneShot(victoryMusic);
        else if(canvasID == 2)
            _audioSource.PlayOneShot(loseMusic);
    }

    private void PlayJumpSound()
    {
        _audioSource.PlayOneShot(jumpSound);
    }

    private void winSound()
    {
        _audioSource.clip = null;
        _audioSource.PlayOneShot(victoryMusic);
    }


    private void ButtonSound()
    {
        _audioSource.PlayOneShot(buttonClickSound);
    }

    private void PlayDoorOpen()
    {

        _audioSource.PlayOneShot(doorOpenSound);
    }
    
    private void OnDisable()
    {
        SUPERCharacterAIO.JumpHappend -= PlayJumpSound;
        GameStatusMenu.canvasIDevent -= ShowCanvas;
    }


}
