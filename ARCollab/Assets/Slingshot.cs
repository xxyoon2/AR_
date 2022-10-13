using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject Pellet;
    private Camera _camera;
    
    public Vector3 PelletLocalOrigin { get {return _pelletLocalOrigin; }}
    private Vector3 _pelletLocalOrigin;
    
    private Pellet _pellet;
    private Vector3 _slingshotPos;
    private Vector3 _defaultPelletPos;
    private Quaternion _defaultPelletRot;
    private bool _isShooting = false;

    private void Awake()
    {
        _camera = GetComponentInParent<Camera>();
        
        _pellet = CreatePellet();
        _pelletLocalOrigin = Pellet.transform.localPosition;
        _slingshotPos = new Vector3(0f, -0.2f, 0.3f);
        _defaultPelletPos = Pellet.transform.localPosition;
        _defaultPelletRot = Pellet.transform.localRotation;

        GameManager.Instance.RespawnPellet.AddListener(PelletSpawner);
        Debug.Log("구독했어요");
    }

    private void Update()
    {
        if(!_isShooting)
        {
            _pellet.transform.localRotation = _defaultPelletRot;
        }
        
        // 터치 시 레이캐스트로 맞은 타겟 정보 받아온 후 총알일 시 발사
        if(Input.touchCount > 0)
        {
            if (_isShooting) return;
            RaycastHit hit;
            Touch touch = Input.GetTouch(0);
            Ray ray = _camera.ScreenPointToRay(touch.position);

            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                Debug.Log($"{hit.transform.name}");
                if(hit.transform.tag == "Pellet" || hit.transform.tag == "Slingshot")
                {
                    _isShooting = true;
                    Shoot();
                }
            }
        }
    }


    private void PelletSpawner()
    {
        if (_pellet.isActiveAndEnabled == true)
        {
            _pellet.gameObject.SetActive(false);
        }

        _pellet = CreatePellet();
    }
    // 총알 생성
    Pellet CreatePellet()
    {
        _isShooting = false;
        Transform pelletWorldTransform = Instantiate(Pellet.transform);
        pelletWorldTransform.SetParent(transform, true);
        pelletWorldTransform.transform.localPosition = _defaultPelletPos;
        pelletWorldTransform.transform.localRotation = _defaultPelletRot;
        pelletWorldTransform.localScale = Pellet.transform.localScale;
        Debug.Log($"총알만들었어요{pelletWorldTransform.position}, {_pelletLocalOrigin}");
        pelletWorldTransform.gameObject.tag = "Pellet";
        //pelletWorldTransform.transform.position = new Vector3(0, 0f, 0.6f);

        return pelletWorldTransform.gameObject.AddComponent<Pellet>();
    }

    void Shoot()
    {
        _pellet.ShootWithSpeedAtCurrentRotation(5f);
    }

}
