using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float StartTimeToShoot;
    [SerializeField] float bulletSpeed;
    float timeToShoot;
    public GameObject player;
    public PlayerMove playerScript;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {

        if (timeToShoot <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                timeToShoot = StartTimeToShoot;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }

        else
        {
            timeToShoot -= Time.deltaTime;
        }

this.transform.position = GameObject.Find("WeaponHolder").transform.position;

      
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        firePoint.rotation = Quaternion.Euler(0, 0, player.GetComponent<PlayerMove>().angle - 90);
        this.transform.rotation = Quaternion.Euler(0, 0, player.GetComponent<PlayerMove>().angle);
        if (player.GetComponent<PlayerMove>().lookDir.x > player.GetComponent<PlayerMove>().lookOffSet.x)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        if (player.GetComponent<PlayerMove>().lookDir.x < -player.GetComponent<PlayerMove>().lookOffSet.x)
        {
            this.transform.localScale = new Vector3(-1, -1, 1);
        }

    }
}
