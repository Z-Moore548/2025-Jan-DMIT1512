using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speedX;
    public float directionX;
    public float speedY;
    public float directionY;

    public float rotationSpeedZ, rotationDirectionZ;

    public float xGrow = 1;
    public float yGrow = 1;

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

        //find width and height of square
        float width = GetComponent<Renderer>().bounds.size.x;
        float height = GetComponent<Renderer>().bounds.size.y;
        
        if (transform.position.x + (width / 2) >= right || transform.position.x - (width / 2) <= left)
        {
            directionX *= -1;
        }
        if (transform.position.y + (height / 2) >= top || transform.position.y - (height / 2) <= bottom)
        {
            directionY *= -1;
        }

        //Growing like a balloon
        
        Vector3 scale = new Vector3(xGrow, yGrow, 0) * Time.deltaTime;
        this.gameObject.transform.localScale += scale;

        if (transform.localScale.x >= 5 || transform.localScale.x <= 1)
        {
            xGrow *= -1;
        }
        if (transform.localScale.y >= 5 || transform.localScale.y <= 1)
        {
            yGrow *= -1;
        }
    }
}
