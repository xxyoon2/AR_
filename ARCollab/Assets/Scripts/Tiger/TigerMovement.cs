using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMovement : MonoBehaviour
{
    public float TigerSpeed = 1f;

    void Update()
    {
        MoveToPlayer();
    }

    // 플레이어의 위치로 다가오는 함수  
    private void MoveToPlayer()
    {
        Quaternion dir = Quaternion.LookRotation(GameManager.Instance.PlayerPos - transform.position);
        Vector3 angle = Quaternion.RotateTowards(transform.rotation, dir, 200 * Time.deltaTime).eulerAngles;

        transform.rotation = Quaternion.Euler(0, angle.y, 0);
        transform.Translate(Vector3.forward * TigerSpeed * Time.deltaTime);
    }
}