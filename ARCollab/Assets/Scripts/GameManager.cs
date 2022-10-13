using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class GameManager : SingletonBehaviour<GameManager>
{
    // ������Ʈ�� ����ڿ� ��ȣ�ۿ��� �� �ִ����� �����ϴ� �̺�Ʈ
    public UnityEvent<bool> CanObjectInteraction = new UnityEvent<bool>();

    public UnityEvent RespawnPellet = new UnityEvent();
    public UnityEvent<float> LetPlayerShoot = new UnityEvent<float>();

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

    // UI���� �Ÿ��� ǥ���ϱ� ���� ����
    public float Dist = 0f;

    private Vector3 _playerPos;
    private Vector3 _objectPos;
    private bool _isUserCloseToObject = false;

    // �Ÿ� ����
    private void MeasureDistance()
    {
        float distance = Vector3.Distance(_objectPos, _playerPos);
        Dist = distance;

        if(distance < 0.5f)
        {
            _isUserCloseToObject = true;
        }
        else
        {
            _isUserCloseToObject = false;
        }
        CanObjectInteraction.Invoke(_isUserCloseToObject);
    }

    public void ShootPellet(float speedPercent)
    {
        LetPlayerShoot.Invoke(speedPercent);
    }

    public void PelletSpawn()
    {
        Debug.Log("��ȯ�ؿ�");
        RespawnPellet.Invoke();
    }
}