using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb;
    public Vector2 movement;
    public Vector3 lookDir;
    public float angle;
    public Vector2 lookOffSet;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLenght;
    public float dashCoolDown;
    public bool isDashing;
    private Camera cam;
    public SpriteRenderer sprite;
    public float playerHealth;
    public Animator anim;
    public int facingDir;
    private string currentState;


    private float dashCounter;
    private float dashCoolCounter;

    //Animation States
    const string IDLE_RIGHT = "MainCharIdleRight";
    const string IDLE_UP = "CharIdleUp";
    const string IDLE_DOWN = "CharIdleDown";
    const string IDLE_DIAGONAL = "CharIdleDiagonal";
    const string RUN_RIGHT = "CharRunRight";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(angle > 60 && angle < 110.5)
        {
            facingDir = 1;
            if(movement.x == 0)
            {
                ChangeAnimationState(IDLE_UP);
            }
            
        }

        else if (angle > 40 && angle < 60 || angle > 125 && angle < 145)
        {
            facingDir = 2;
            if (movement.x == 0)
            {
                ChangeAnimationState(IDLE_DIAGONAL);
            }
        }

        else if (angle > -45 && angle < 40 || angle > 145 && angle < 180 || angle > -135 && angle < -180)
        {
            facingDir = 3;
            if (movement.x == 0)
            {
                ChangeAnimationState(IDLE_RIGHT);
            }
        }

        else if (angle > -135 && angle < -45)
        {
            facingDir = 4;
            if (movement.x == 0)
            {
                ChangeAnimationState(IDLE_DOWN);
            }
        }

        if (movement.x != 0)
        {
            ChangeAnimationState(RUN_RIGHT);
        }

        lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookDir.Normalize();
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (isDashing == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
       
        if (Input.GetMouseButtonDown(1))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                isDashing = true;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLenght;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                isDashing = false;
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if(dashCoolDown > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * activeMoveSpeed, movement.y * activeMoveSpeed);
        if (lookDir.x > lookOffSet.x)
        {
            this.transform.localScale = new Vector3(1, 1, 1);

        }

        if (lookDir.x < -lookOffSet.x)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }
}
