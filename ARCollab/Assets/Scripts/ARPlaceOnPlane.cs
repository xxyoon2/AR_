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
                if(!_spawnObject)
                {
                    _spawnObject = Instantiate(TigerPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    _spawnObject.transform.position = hitPose.position;
                    //_spawnObject.transform.LookAt(GameManager.Instance.PlayerPose);
                }
            }
        }
    }

    private void UpdateCenterObject()
    {   //카메라의 센터를 받아오는 함수
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(screenCenter, hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            TigerPrefab.SetActive(true);
            TigerPrefab.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }

    }
}
