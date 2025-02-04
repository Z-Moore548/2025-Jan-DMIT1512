using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public int upperRandomRangeForFireingRate;
    
    void Update()
    {
        int rando = Random.Range(1, upperRandomRangeForFireingRate);
        if(rando == 1)
        {
            Fire();
        }
    }

    private void Fire()
    {
        //Instantiate one projectile prefab
        GameObject Projectile = Instantiate(ProjectilePrefab);

        float myHeight = GetComponent<Renderer>().bounds.size.y;
        float ProjectileHeight = Projectile.GetComponent<Renderer>().bounds.size.y;
        Vector3 newPosition = transform.position - new Vector3(0, (myHeight / 2) + (ProjectileHeight / 2));
        Projectile.transform.position = newPosition; 

        Projectile.GetComponent<Projectile>().speed = 10;
        Projectile.GetComponent<Projectile>().direction.y = -1;
    }
}