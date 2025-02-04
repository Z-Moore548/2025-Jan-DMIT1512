using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
    //Once weve set up the projectile as a Kenimatic Rigidbody Trigger Collider
    //and whatedver were going to to hit at least has a collider.
    //The below code should run when two game objects touch
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("PlayerShip"))
        {
            Destroy(collider2D.gameObject);
        }

    }
}
