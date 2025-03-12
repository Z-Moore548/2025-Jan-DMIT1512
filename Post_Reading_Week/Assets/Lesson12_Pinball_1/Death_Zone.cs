using System.Collections;
using UnityEngine;

public class Death_Zone : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    void Start()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = ballSpawnPoint.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        StartCoroutine(WaitThenSpawnBall());
    }

    IEnumerator WaitThenSpawnBall()
    {
        yield return new WaitForSeconds(1); //go away then come back in one second
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = ballSpawnPoint.position;
        yield return new WaitForSeconds(1); //go away then come back in one second
        GameObject newBall2 = Instantiate(ballPrefab);
        newBall2.transform.position = ballSpawnPoint.position;
    }
}
