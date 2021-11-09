using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MaggotIA : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float nextWayPointDistance;
    Path path;
    int currentWayPoint;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public int health;
    private Animator anim;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.1f);
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        else
        {
            reachedEndOfPath = false;
        }

        Vector2 diraction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = diraction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

            if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (rb.velocity.y > 0.2 && rb.velocity.x < 0.2)
        {
            anim.Play("MaggotUp");
        }

        else
        {
            anim.Play("MaggotRight");
        }

        if (rb.velocity.x >= 0.01)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        else if (rb.velocity.x <= -0.01)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMove>().playerHealth -= 1;
        }
    }
}
