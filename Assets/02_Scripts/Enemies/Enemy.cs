using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    public int health;
    public AIPath aiPath;
    private float timeToShoot;
    public float startTimeToShot;
    public GameObject enemyBullet;
    public float bulletSpeed;
    public Transform enemyFirePoint;
    private void Start()
    {
        timeToShoot = startTimeToShot;
    }
    void Update()
    {
        if (timeToShoot <= 0)
        {
            Shoot();
            timeToShoot = startTimeToShot;
        }

        else
        {
            timeToShoot -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (aiPath.desiredVelocity.x >= 0.01)
        { 
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        else if (aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

      
    } 
    void Shoot()
        {
            GameObject bullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(enemyFirePoint.up * bulletSpeed, ForceMode2D.Impulse);

        }
}
