using UnityEngine;

public class Parent : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }
    //a Gizmo is somthing that is drawn in the game editor but invisible during gameplay
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
