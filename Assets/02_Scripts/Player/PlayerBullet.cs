using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Maggot"))
        {
            other.GetComponent<MaggotIA>().health -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Bee"))
        {
            other.GetComponent<BeeIA>().health -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
    }
}
