using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Rigidbody _rigidBody = null;
    private SphereCollider _sphereCollider = null;
    private float _speed = 0;

    void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.useGravity = false;
        _rigidBody.drag = 1f;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _sphereCollider.radius = transform.localScale.x * 3.8f;

        GameManager.Instance.LetPlayerShoot.AddListener(ShootWithSpeedAtCurrentRotation);
    }

    // 컴포넌트에 rigidBody가 포함되어 있으면 총알 발사
    private void ShootWithSpeedAtCurrentRotation(float speedPercent)
    {
        if (_rigidBody == null) return;

        _rigidBody.useGravity = true;
        _speed = 50f * speedPercent;
        _rigidBody.AddRelativeForce(0f, 200f, _speed);
        Invoke("SpawnEventInvoke", 5f);
    }
    
    // 타겟과 충돌 시 비활성화
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            SpawnEventInvoke();
        }
    }

    private void SpawnEventInvoke()
    {
        GameManager.Instance.PelletSpawn();
        gameObject.SetActive(false);
    }
}
