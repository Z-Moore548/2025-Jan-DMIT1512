using UnityEngine;

public class Coin : MonoBehaviour
{
    private SoundHub _soundHUB;
    void Awake()
    {
        _soundHUB = GameObject.Find("SoundHub").GetComponent<SoundHub>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
            //  I think this is fine as you would normally have a pickup animations
        // _coinPickUpSound.Play();
        // Destroy(this.gameObject, _coinPickUpSound.clip.length);

        _soundHUB.PlayCoinSound();
        Destroy(this.gameObject);

        //for lab. need to keep trach of how many coins are picked up in gamestate
    }
}
