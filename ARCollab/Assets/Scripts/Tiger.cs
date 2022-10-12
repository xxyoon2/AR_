using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TigerState
{
    Idle,
    Run,
    Dead
}

public class Tiger : MonoBehaviour
{
    public DebugLog Log;

    public float TigerSpeed = 0.05f;
    private float gravity = -9.8f;
    private Animator _tigerAnimator;
    //private TigerState _tigerState;

    private void Start()
    {
        //_tigerState = TigerState.Idel;
        //_tigerState = TigerState.Run;
        _tigerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveToPlayer();
    }

    void ChangeState(TigerState tigerState)
    {
        switch (tigerState)
        {
            case TigerState.Idle:
                _tigerAnimator.SetBool("Idle", true);
                break;
            case TigerState.Run:
                _tigerAnimator.SetBool("Run Forward", true);
                break;
            case TigerState.Dead:
                break;
        }
    }

    private void MoveToPlayer()
    {
        Quaternion dir = Quaternion.LookRotation(GameManager.Instance.PlayerPos - transform.position);
        Vector3 angle = Quaternion.RotateTowards(transform.rotation, dir, 200 * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0, angle.y, 0);
        transform.Translate(Vector3.forward * Time.deltaTime);
        _tigerAnimator.SetBool("Run Forward", true);
    }
}