using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public float raycastDistance = 1.1f; // 땅을 감지하기 위한 광선의 길이
    public LayerMask groundLayer; // 땅 레이어

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 땅에 닿았는지 체크
        isGrounded = Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer);

        // 점프 입력을 받고 땅에 닿았을 때만 점프 실행
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // 이동 입력 처리
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f).normalized;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, 0f);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

