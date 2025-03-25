using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Pinball01_UI : MonoBehaviour
{
    private GameStatePinball _gameState;
    private Label _currentScoreLabel;
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStatePinball>();
        _currentScoreLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("CurrentScoreLabel");
        _currentScoreLabel.text = _gameState.CurrentScore + "";
    }
    // Update is called once per frame
    void Update()
    {
        //Only update UI if Nessesary
        if(int.Parse(_currentScoreLabel.text) != _gameState.CurrentScore)
        {
            _currentScoreLabel.text = _gameState.CurrentScore + "";
        }
    }
}
