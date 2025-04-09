using UnityEngine;

public class SoundHub : MonoBehaviour
{
    private AudioSource _coinPickUpSound;
    
    void Awake()
    {
        _coinPickUpSound = GetComponent<AudioSource>();
    }
    public void PlayCoinSound()
    {
        _coinPickUpSound.Play();
    }
}
