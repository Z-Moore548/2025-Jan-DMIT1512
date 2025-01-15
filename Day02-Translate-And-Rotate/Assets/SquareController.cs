using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speedX;
    public float directionX;
    public float speedY;
    public float directionY;

    public float rotationSpeedZ, rotationDirectionZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementAmount = new Vector2(speedX * directionX, speedY * directionY) * Time.deltaTime;
        //"transform" automatically refers to the transform of the game object that the script is attached to
        transform.Translate(movementAmount, Space.World);
        //the above is short for
        //this.gameObject.transform.Translate(movementAmount); 
        

        //We pass it 3 "Euler values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);

        //Find the screen bounds in world space
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        float left = bottomLeft.x;
        float right = topRight.x;
        float bottom = bottomLeft.y;
        float top = topRight.y;

        if (transform.position.x >= right - 0.5 || transform.position.x <= left + 0.5)
        {
            directionX *= -1;
        }
        if (transform.position.y >= top - 0.5 || transform.position.y <= bottom + 0.5)
        {
            directionY *= -1;
        }
    }
}
