using System;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    public int _currentScore;
    public int _highScore;
}
/*thinsg to do for lab: 
    -In awake, Load Data
    -in pinball scene, save data when the scene is unloaded: 
        in the Death Zone class add this method
        void OnDestory
        {
            Debug.Log("Scene is unloading (OnDestory)")
            //Save Data Here
        }
    -Alter UI so the opening Scene only displays High Score, not Current Score
    -Add Logic so it only saves the HIgh score if current score is Greater than the High Score
*/
public class GameStatePinball : MonoBehaviour
{
    private GameData _gameData;
    public int CurrentScore
    {
        get => _gameData._currentScore;
        set => _gameData._currentScore = value;
    }
    public int HighScore
    {
        get => _gameData._highScore;
        set => _gameData._highScore = value;
    }
    void Awake()
    {
        GameObject [] objs = GameObject.FindGameObjectsWithTag("GameState");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        _gameData = new GameData();
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveToDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "Conrad.txt");
        string jsonString = JsonUtility.ToJson(_gameData);
        Debug.Log("Saving score to " + Application.persistentDataPath);
        using(StreamWriter streamWriter = File.CreateText(dataPath))
        {
            streamWriter.Write(jsonString);
            Debug.Log(dataPath);
        }
    }
    public void LoadFromDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "Conrad.txt");
        using (StreamReader streamReader = File.OpenText(dataPath))
        {
            //get the string that we wrote to the file
            string jsonString = streamReader.ReadToEnd();
 
            //convert the string to an object
            JsonUtility.FromJsonOverwrite(jsonString, _gameData);
        }
    }
}
