using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float hMovement, vMovement;
    bool isRunning = false;

    [SerializeField] float moveSpeed;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        virtualCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        hMovement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
        if (Input.GetButton("Fire2"))
        {
            isRunning = true;
            virtualCamera.gameObject.SetActive(true);
        }
        else
        {
            isRunning = false;
            virtualCamera.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1;
        if(isRunning )
        {
            speedMultiplier = 1.5f;
        }
        rb.velocity = new Vector2(hMovement, vMovement) * moveSpeed * speedMultiplier;
    }
}
