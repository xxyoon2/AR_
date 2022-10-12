using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class GameManager : SingletonBehaviour<GameManager>
{
    // 오브젝트가 사용자와 상호작용할 수 있는지를 전달하는 이벤트
    public UnityEvent<bool> CanObjectInteraction = new UnityEvent<bool>();

    public Vector3 PlayerPos
    {
        get
        {
            return _playerPos;
        }
        set
        {
            _playerPos = value;
            Invoke("MeasureDistance", 0.1f);
        }
    }

    public Quaternion PlayerRot
    {
        get
        {
            return _playerRot;
        }
        set
        {
            _playerRot = value;
        }
    }

    public Vector3 ObjectPos
    {
        get
        {
            return _objectPos;
        }
        set
        {
            _objectPos = value;
        }
    }

    public Vector3 TigerPos
    {
        get
        {
            return _tigerPos;
        }
        set
        {
            _tigerPos = value;
        }
    }

    // UI에서 거리를 표시하기 위한 변수
    public float Dist = 0f;

    private Vector3 _playerPos;
    private Quaternion _playerRot;
    private Vector3 _objectPos;
    private Vector3 _tigerPos;
    private bool _isUserCloseToObject = false;

    // 거리 측정
    private void MeasureDistance()
    {

        float distance = Vector3.Distance(_objectPos, _playerPos);
        Dist = distance;

        if (distance < 0.5f)
        {
            _isUserCloseToObject = true;
        }
        else
        {
            _isUserCloseToObject = false;
        }
        CanObjectInteraction.Invoke(_isUserCloseToObject);
    }
}