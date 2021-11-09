using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMove>().playerHealth -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
    }


}
