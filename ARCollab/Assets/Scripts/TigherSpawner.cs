using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigherSpawner : MonoBehaviour
{
    public GameObject TigerPrefab;

    [SerializeField]
    private float distance = 3.0f;

    private void Start()
    {
        //ȣ���� ����ȭ or ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
       

       //GameManager.Instance.TigerPos = transform.position;
    }

    private void PosInfo()
    {
        var TigerPose = GameManager.Instance.PlayerPos;
        var TigerRot = GameManager.Instance.PlayerRot;

        TigerPrefab.transform.position = TigerPose;
        TigerPrefab.transform.rotation = TigerRot;



    }
}
