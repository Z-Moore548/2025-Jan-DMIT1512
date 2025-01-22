using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float growAndShrinkSpeed;
    private InputAction _moveAction;
    private InputAction _rotateRight;
    private InputAction _rotateLeft;
    private InputAction _spinAction;
    private InputAction _grow;
    private InputAction _shrink;
    private InputAction _GandSAction;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _rotateLeft = InputSystem.actions.FindAction("SpinLeft"); //My rotation
        _rotateRight = InputSystem.actions.FindAction("SpinRight"); //My rotation
        _spinAction = InputSystem.actions.FindAction("Spin");
        _grow = InputSystem.actions.FindAction("Grow");
        _shrink = InputSystem.actions.FindAction("Shrink");
        _GandSAction = InputSystem.actions.FindAction("GAndS");
    }

    void Update()
    {
        //movement
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue *= Time.deltaTime * moveSpeed;
        transform.Translate(translationValue, Space.World);
        
        // //My rotation (didnt have full info, does work but not best)
        // if (_rotateLeft.IsPressed())
        // {
        //     transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
        // }
        // if (_rotateRight.IsPressed())
        // {
        //     transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime);
        // }

        //Teacher Roation (way faster and better)
        float spinDirection = _spinAction.ReadValue<float>();
        //Debug.Log(spintDirection); 
        transform.Rotate(0, 0, spinDirection * rotationSpeed * Time.deltaTime);

        // //My grow and shrink (didnt have full info, does work but not best)
        // if (_grow.IsPressed())
        // {
        //     this.gameObject.transform.localScale += new Vector3(1 * growAndShrinkSpeed, 1 * growAndShrinkSpeed, 0) * Time.deltaTime;
        // }
        // if (_shrink.IsPressed())
        // {
        //     this.gameObject.transform.localScale += new Vector3(-1 * growAndShrinkSpeed, -1 * growAndShrinkSpeed, 0) * Time.deltaTime;
        // }
        
        //Teacher Grow and Shrink (way faster and better)
        float growDirection = _GandSAction.ReadValue<float>();
        transform.localScale += new Vector3(growDirection * growAndShrinkSpeed, growDirection * growAndShrinkSpeed, 0) * Time.deltaTime;
    }
}
