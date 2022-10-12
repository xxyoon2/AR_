using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject TigerPrefab;

    private GameObject _spawnObject;
    private Pose _startPos;

    private void Start()
    {
        GameManager.Instance.CanObjectInteraction.AddListener(BacktoStartPos);
    }

    private void Update()
    {
        PlaceTigerByTouch();
    }

    private void PlaceTigerByTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                _startPos = hitPose;

                if(!_spawnObject)
                {
                    _spawnObject = Instantiate(TigerPrefab, hitPose.position, hitPose.rotation);
                }
                //else
                //{
                //    _spawnObject.transform.position = hitPose.position;
                //    _spawnObject.transform.LookAt(GameManager.Instance.PlayerPos);
                //}
            }
        }
    }

    // 특정 오브젝트와 거리가 가까워졌을 경우 시작점으로 돌아감
    void BacktoStartPos(bool isBump)
    {
        if (isBump)
        {
            _spawnObject.transform.position = _startPos.position;
            _spawnObject.transform.rotation = _startPos.rotation;
        }
    }
}
