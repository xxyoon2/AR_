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

        // 동시에 여러 손가락으로 터치했을 경우, 첫번째 터치만 인식
        Touch touch = Input.GetTouch(0);

        // ColliderEnter와 비슷
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray;
            RaycastHit hit;

            ray = _camera.ScreenPointToRay(touch.position);

            // 범위 제한과 레이어 마스크 구분으로 터치 가능한 오브젝트만 인식하기
            float distance = 5f;
            if (Physics.Raycast(ray, out hit, distance))
            {
                // 찾았을 경우, SetActive(false)
                hit.transform.GetComponent<Tiger>()?.Die();
            }
        }
    }
}
