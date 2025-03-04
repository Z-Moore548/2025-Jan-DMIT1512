using UnityEngine;

//Vorsicht!
//This script must be a component of a game object that is tagged with GameState in the opening scene of the game
public class GameState : MonoBehaviour
{   
    private int _score = 0;

    public int Score { get => _score; set => _score = value; }

    void Awake()
    {
        //make this object exist between scenes
        GameObject [] objs = GameObject.FindGameObjectsWithTag("GameState");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
