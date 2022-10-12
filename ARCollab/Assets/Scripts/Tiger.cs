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
    public float TigerSpeed = 0.2f;

    private Animator _tigerAnimator;
    //private TigerState _tigerState;

    private void Start()
    {
        //_tigerState = TigerState.Idel;
        //_tigerState = TigerState.Run;
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
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.PlayerPos, TigerSpeed);
        _tigerAnimator.SetBool("Run Forward", true);
        ChangeState(TigerState.Run);
    }


    
}