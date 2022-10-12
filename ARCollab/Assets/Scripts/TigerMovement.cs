using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TigerState
{
    Idle,
    Run,
    Dead
}

public class TigerMovement : MonoBehaviour
{
    public float TigerSpeed = 0.2f;
    
    private TigerState _tigerState;

    private void Start()
    {
        //_tigerState = TigerState.Idel;
        _tigerState = TigerState.Run;
        GameManager.Instance.CanObjectInteraction.AddListener(BacktoStartPos);
    }

    void Update()
    {
        if(_tigerState == TigerState.Run)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.PlayerPos , TigerSpeed);   
        }
    }

    bool BacktoStartPos(bool _isBump)
    {

    }

}