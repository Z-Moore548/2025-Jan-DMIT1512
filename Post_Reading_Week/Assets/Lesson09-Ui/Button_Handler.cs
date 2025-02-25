using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene01_Button_Handler : MonoBehaviour
{
    private void OnEnable()
    {
        //get the root ui element 
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button changeToScene02Button = root.Q<Button>("ChangeToScene02Button");
        if(changeToScene02Button != null)
        {
            changeToScene02Button.clicked += ChangeToScene02;
        }
        Button changeToScene01Button = root.Q<Button>("ChangeToScene01Button");
        if(changeToScene01Button != null)
        {
            changeToScene01Button.clicked += ChangeToScene01;
        }
    }

    private void ChangeToScene02()
    {
        SceneManager.LoadScene("Scene02");
    }
    private void ChangeToScene01()
    {
        SceneManager.LoadScene("Scene01");
    }
}