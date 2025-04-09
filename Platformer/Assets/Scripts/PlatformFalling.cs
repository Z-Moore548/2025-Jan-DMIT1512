using System.Collections;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody2D _myRigidBody;
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _renderer.material.color = Color.green;
        StartCoroutine("WaitThenFall");
    }
    IEnumerator WaitThenFall()
    {
        yield return new WaitForSeconds(2);
        _myRigidBody.bodyType = RigidbodyType2D.Dynamic;
    }
}
