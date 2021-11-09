using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{ 
private Vector3 mousePos;
private Vector3 lookDir;
private SpriteRenderer sprite;
    public Vector2 lookOffSet;
    public Camera cam;

private void Start()
{
        sprite = GetComponent<SpriteRenderer>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            
}
void Update()
{
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    lookDir = mousePos - transform.position;
}

    private void FixedUpdate()
    {
        this.transform.position = GameObject.Find("WeaponHolder").transform.position;

        if (lookDir.x > lookOffSet.x)
        {
        }

        if (lookDir.x < -lookOffSet.x)
        {

        }
    }
}
