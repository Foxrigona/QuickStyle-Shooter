using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float dashFactor = 2f;
    [SerializeField] private float dashTime = 1f;
    private Vector3 movementVector = new Vector3();
    private bool isDashing = false;
    private Vector3 originalPos;
    private Vector3 newPos;
    private float dashTimer = 0f;


    private Rigidbody2D killer;
    public AudioSource dashNoise;

    public void Start()
    {
        killer = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        handleMovement();
        if (Input.GetMouseButtonDown(1) && !isDashing)
        {
            isDashing = true;
            this.originalPos = new Vector3(transform.position.x, transform.position.y);
            this.newPos = originalPos + movementVector.normalized * dashFactor;
        }
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            dash();
            if(dashTimer >= dashTime)
            {
                this.isDashing = false;
                this.dashTimer = 0f;
            }
        }
    }

    private void dash()
    {
        Debug.Log(dashTimer);
        transform.position = Vector3.Lerp(originalPos, newPos, dashTimer/dashTime);
        dashNoise.Play();
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
            movementVector.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
            movementVector.y = -1;
        }
        else
        {
            movementVector.y = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            movementVector.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            movementVector.x = 1;
        }
        else
        {
            movementVector.x = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            //ADD A HEALTH DROP
            Debug.Log("In a wall. Kill them");

            
        }
    }
}
