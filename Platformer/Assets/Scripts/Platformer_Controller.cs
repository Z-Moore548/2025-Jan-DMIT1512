using UnityEngine;
using UnityEngine.InputSystem;

public class Platformer_Controller : MonoBehaviour
{
    public float maxSpeed; //5
    public float jumpForce;//100
    public float moveForce;//365
    public Transform groundCheck;
    private Rigidbody2D _myRigiddBody;
    private Animator _myAnimator;
    private InputAction _jump;
    private InputAction _move;
    private bool _grounded;
    private bool _initiateJump;
    

    void Awake()
    {
        _myRigiddBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _initiateJump = false;
    }

    void Update()
    {
        //remember to make all platforms belong to the ground layer.
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _initiateJump = true;
        }
    }

    void FixedUpdate()
    {
        float horizantalMovement = _move.ReadValue<Vector2>().x;

        //have we reached _maxSpeed? if not, add force.
        //It works going left becuase horizantalMovement and _myRigidBody.Velocity.x will both be negative at the same time.
        if(horizantalMovement * _myRigiddBody.linearVelocityX < maxSpeed)
        {
            _myRigiddBody.AddForce(Vector2.right * horizantalMovement * moveForce);
        }
        //have we exceeded the maxSpeed, set to maxSpeed
        if(Mathf.Abs(_myRigiddBody.linearVelocityX) > maxSpeed)
        {
            _myRigiddBody.linearVelocity = new Vector2(Mathf.Sign(_myRigiddBody.linearVelocityX) * maxSpeed, _myRigiddBody.linearVelocityY);
        }
        if(_initiateJump)
        {
            _myRigiddBody.AddForce(new Vector2(0, jumpForce));
            _myAnimator.SetTrigger("Jump");
            _initiateJump = false;
        }
    }
}
