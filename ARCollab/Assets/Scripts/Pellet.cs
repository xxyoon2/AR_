using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{

    private Rigidbody _rigidBody = null;
    private SphereCollider _sphereCollider = null;

    private float _speed = 0;
    private Vector3 _defaultPos;

    void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidBody = GetComponent<Rigidbody>();
        
        _rigidBody.useGravity = true;
        _rigidBody.drag = 1f;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _sphereCollider.radius = transform.localScale.x * 3.8f;

    }

    // 컴포넌트에 rigidBody가 포함되어 있지 않으면 총알 발사
    public void ShootWithSpeedAtCurrentRotation(float speedPercent)
    {
        if (_rigidBody == null) return;

        _speed = 50f * speedPercent;
        _rigidBody.AddForce(0, _speed, 200);
    }
    
    // 타겟과 충돌 시 비활성화
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            gameObject.SetActive(false);
        }
    }
}
