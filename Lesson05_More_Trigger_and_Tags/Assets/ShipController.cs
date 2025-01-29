using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float movementSpeed;
    private InputAction _moveAction;
    private bool _maxLeftReached = false, _maxRightReached = false;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue.y = 0;
        translationValue *= Time.deltaTime * movementSpeed;
        //if we're trying to move right
        if (translationValue.x > 0 && !_maxRightReached)
        {
            transform.Translate(translationValue);
        }
        else if (!_maxLeftReached && translationValue.x < 0) //were moving left
        {
            transform.Translate(translationValue);
        }

    }

    /*
        There are 3 methods that deal with tirgger collision:
        OnTriggerEnter2D - Called when they frist come into contact
        OnTriggerStay2D - Called every frame during witch they are in contact
        OnTriggerExit2D - Called when they stop being in contact
    */
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        //is the thing that i collided with on my left?
        if(collider2D.CompareTag("WallLeft"))
        {
             _maxLeftReached = true;
        }
        if(collider2D.CompareTag("WallRight"))//its on my right
        {
            _maxRightReached = true;
        }
    }
    // void OnTriggerStay2D(Collider2D collider2D)
    // {
    //     Debug.Log("#####################ON TRIGGER STAY 2D########################");
    // }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("WallLeft"))
        {
             _maxLeftReached = false;
        }
        if(collider2D.CompareTag("WallRight"))
        {
            _maxRightReached = false;
        };
    }
}
