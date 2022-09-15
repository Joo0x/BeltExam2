using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip jumpSound,shoootSound,dyingSound,damageSound,buttonClickSound,levelMusic,victoryMusic;
    [SerializeField] private Image HPImage;
    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        HPImage = GetComponent<Image>();
    }

    private void OnEnable()
    {

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

    private void DamageSound(float currentHealth)
    {
        HPImage.fillAmount = currentHealth / 10;
        _audioSource.PlayOneShot(damageSound);
    }

    private void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSound);
    }

    private void OnDisable()
    {



    }


}
