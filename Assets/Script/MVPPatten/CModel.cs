using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CModel
{
    // 캐릭터의 모델 데이터
    public float MoveSpeed { get; set; } = 5f;
    public float JumpForce { get; set; } = 10f;
    public bool IsGrounded { get; set; } = false;
    public Transform GroundCheck { get; set; }
    public float CheckRadius { get; set; } = 0.1f;
    public LayerMask GroundLayer { get; set; }
    public Rigidbody2D Rigidbody { get; set; }
}
