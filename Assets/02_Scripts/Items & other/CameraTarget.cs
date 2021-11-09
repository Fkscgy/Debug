using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float threshold;
    private Vector3 mousePos;
    private Vector3 refVel;
    [SerializeField] private float smoothTime;
    private Vector3 smoothVector;
   


    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;
        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);
        smoothVector = Vector3.SmoothDamp(transform.position, targetPos, ref refVel, smoothTime);
    }

    private void FixedUpdate()
    {
        this.transform.position = smoothVector;

    }
}
