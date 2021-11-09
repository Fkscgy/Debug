using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] Transform atackPos;
    [SerializeField] float atackRange;
    [SerializeField] private float startTimeToAttack;
    [SerializeField] Vector3 knockBackOffSet;
    private float timeToAtack;
    public LayerMask enemies;
    public int damage;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (timeToAtack <= 0)
        {
            #region     
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Attacked");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atackPos.position, atackRange, enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                    enemiesToDamage[i].GetComponent<Rigidbody2D>().transform.position += knockBackOffSet;

                }
                timeToAtack = startTimeToAttack;
            }
        }

        else
        {
            timeToAtack -= Time.deltaTime;
        }
        #endregion
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atackPos.position, atackRange);
    }

   
}
