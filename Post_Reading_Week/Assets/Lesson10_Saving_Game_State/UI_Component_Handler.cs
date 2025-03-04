using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_Component_Handler : MonoBehaviour
{
    private Button _increaseScoreButton;
    private Label _scoreLabel;

    //in and script that needs to read or write to gamestate, follow the steps in this script

    //Step 1: declare a gamestate dataMember
    private GameState gameState;
    
    void Awake()
    {
        //Step 2: in Awake do this
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _increaseScoreButton = root.Q<Button>("IncreaseScoreButton");
        _scoreLabel = root.Q<Label>("ScoreLabel");
        _scoreLabel.text = gameState.Score + "";
        _increaseScoreButton.clicked += IncreaseScore;

        Button changeToScene02Button = root.Q<Button>("ChangeToScene02Button");
        changeToScene02Button.clicked += ChangeToScene02;

    }

    private void IncreaseScore()
    {
        gameState.Score++;
        _scoreLabel.text = gameState.Score + "";
    }

    private void ChangeToScene02()
    {
        SceneManager.LoadScene("Scene2");
    }
}
