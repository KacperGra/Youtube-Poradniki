using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody;

    private Vector3 input;

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        input = new Vector3(inputX, inputY, 0);
        // transform.position += input * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
        rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y);

        // rigidbody.MovePosition(transform.position + move);
    }

    public Vector3 GetInput()
    {
        return input;
    }

    public bool IsMoving()
    {
        return input.x != 0;
    }
}