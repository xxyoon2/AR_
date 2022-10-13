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

    public void removeAllForces()
    {
        if (_rigidBody == null) return;
        _rigidBody.velocity = Vector3.zero;
    }
    
    public void ShootWithSpeedAtCurrentRotation(float speedPercent)
    {
        if (_rigidBody == null) return;

        _speed = 50f * speedPercent;
        _rigidBody.AddForce(0, _speed, 200);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            gameObject.SetActive(false);
        }
    }
}
