using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager ArRaycaster;
    public GameObject SpawnObject;

    private GameObject _spawnObject;

    private void Start()
    {

    }

    private void Update()
    {
        PlaceTigerByTouch();
    }

    // 모바일 화면 터치 시, 터치 부분에 오브젝트를 생성하는 함수
    // 배치된 오브젝트는 플레이어를 바라봄
    private void PlaceTigerByTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (ArRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if(!_spawnObject)
                {
                    _spawnObject = Instantiate(SpawnObject, hitPose.position, hitPose.rotation);
                }
                else
                {
                    _spawnObject.transform.position = hitPose.position;
                    _spawnObject.transform.LookAt(GameManager.Instance.PlayerPos);
                }
            }
        }
    }
}
