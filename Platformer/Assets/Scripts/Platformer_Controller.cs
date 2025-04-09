using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platformer_Controller : MonoBehaviour
{
    public float maxSpeed, jumpForce, moveForce;
    public Transform groundCheck;
    public AudioClip firstClip;
    public AudioClip secondClip;
    private AudioSource myAudio;
    private Rigidbody2D _myRigiddBody;
    private Animator _myAnimator;
    private InputAction _jump, _move;
    private bool _grounded, _jumpInitiated, _facingRight;
    

    void Awake()
    {
        _myRigiddBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _jumpInitiated = false;
        _facingRight = true;
    }

    void Update()
    {
        //remember to make all platforms belong to the ground layer.
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _jumpInitiated = true;
            myAudio.PlayOneShot(secondClip);
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
            _myRigiddBody.linearVelocityX = Mathf.Sign(_myRigiddBody.linearVelocityX) * maxSpeed;
        }
        if(_jumpInitiated)
        {
            _myRigiddBody.AddForce(new Vector2(0f, jumpForce));
            _myAnimator.SetTrigger("Jump");
            _jumpInitiated = false;
        }

        if((horizantalMovement > 0 && !_facingRight) || (horizantalMovement < 0 && _facingRight))
        {
            Flip();
        }
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
