using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController3D : MonoBehaviour
{
    public float fallMultiplier = 2.5f; // 중력을 증폭시키는데 사용될 계수
    public float lowJumpMultiplier = 2f; // 낮은 점프를 구현하는데 사용될 계수

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0) // 오브젝트가 점프 후 공중에 있는 경우
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) // 점프 입력을 유지하지 않으면서 위로 움직이는 중인 경우
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
