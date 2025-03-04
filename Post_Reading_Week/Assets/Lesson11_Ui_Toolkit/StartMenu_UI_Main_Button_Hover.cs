using UnityEngine;
using UnityEngine.UIElements;

public class StartMenu_UI_Main_Button_Hover : MonoBehaviour
{
    private StyleColor startButtonOriginalColor;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        if(root == null)
        {
            Debug.Log("UI Document not found");
        }
        else
        {
            Button startButton = root.Q<Button>("StartGameButton");
            startButtonOriginalColor = startButton.style.backgroundColor;

            //tell the mouse enter event to run the method when it occurs
            startButton.RegisterCallback<MouseEnterEvent>(evt => OnButtonHover(startButton));
            startButton.RegisterCallback<MouseLeaveEvent>(evt => OnButtonExit(startButton, startButtonOriginalColor));

            // root.Q<Button>("OptionsButton").clicked += OpenOptions;
            // root.Q<Button>("QuitButton").clicked += QuitGame;
        }
    }

    private void OnButtonHover(Button button)
    {
        button.style.backgroundColor = new StyleColor(new Color(0.5f, 0.8f, 0.5f));
        button.style.scale = new StyleScale(new Vector3(1.05f, 1.05f, 1f));
    }
    private void OnButtonExit(Button button, StyleColor originalColor)
    {
        button.style.backgroundColor = originalColor;
        button.style.scale = new StyleScale(Vector3.one);
    }
}
