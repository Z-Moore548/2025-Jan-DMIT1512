using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private GameStatePinball _gameState;
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStatePinball>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Have different game objects be worth different amounts, give them tags and check the tags here
        _gameState.CurrentScore++;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //suggestion: Change a UI Label On the Scene to Game Over then Wait 5 Seconds with a co routine then run below code.
        SceneManager.LoadScene("StartScene");
    }
}
