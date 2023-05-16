using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 6f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private GroundChecker groundChecker;

    private bool isJumping = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}