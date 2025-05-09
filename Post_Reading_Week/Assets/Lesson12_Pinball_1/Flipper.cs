using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    private GameStatePinball _gameState;
    private HingeJoint2D joint2D;
    private InputAction _flipRight, _flipLeft;
    public enum FlipperType 
    {
        Right, Left
    }
    public FlipperType _type;
    void Awake()
    {
        //_gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStatePinball>();
    }
    void Start()
    {
        joint2D = GetComponent<HingeJoint2D>();
        _flipRight = InputSystem.actions.FindAction("FlipperRight");
        _flipLeft = InputSystem.actions.FindAction("FlipperLeft");
    }

    void Update()
    {
        switch(_type)
        {
            case(FlipperType.Right):
                joint2D.useMotor = _flipRight.IsPressed();
                break;
            case(FlipperType.Left):
                joint2D.useMotor = _flipLeft.IsPressed();
                break;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hello");
        //_gameState.CurrentScore++;
    }
}
