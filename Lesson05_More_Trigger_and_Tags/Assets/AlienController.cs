using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    public float speed;
    private Vector2 _direction = new Vector2(-1, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * _direction * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        _direction.x *= -1;
    }
}
