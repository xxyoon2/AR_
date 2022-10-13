using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        // ���ÿ� ���� �հ������� ��ġ���� ���, ù��° ��ġ�� �ν�
        Touch touch = Input.GetTouch(0);

        // ColliderEnter�� ���
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray;
            RaycastHit hit;

            ray = _camera.ScreenPointToRay(touch.position);

            // ���� ���Ѱ� ���̾� ����ũ �������� ��ġ ������ ������Ʈ�� �ν��ϱ�
            float distance = 5f;
            if (Physics.Raycast(ray, out hit, distance))
            {
                // ã���� ���, SetActive(false)
                hit.transform.GetComponent<Tiger>()?.Die();
            }
        }
    }
}
