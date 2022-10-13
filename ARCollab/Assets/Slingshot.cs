using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject Pellet;

    private Camera _camera;
    public Vector3 PelletLocalOrigin { get {return _pelletLocalOrigin; }}
    private Vector3 _pelletLocalOrigin;

    private Vector3 _slingshotPos;
    private Pellet _pellet;
    private bool _isShooting = false;
    private Vector3 _defaultPelletPos;
    private Quaternion _defaultPelletRot;

    [SerializeField]
    private float _distAheadOffset = 0.5f;
    private float _pullbackPercent = 0f;

    private void Awake()
    {
        _camera = GetComponentInParent<Camera>();
        _pelletLocalOrigin = Pellet.transform.localPosition;
        _pellet = CreatePellet(transform, Pellet.transform);
        _slingshotPos = new Vector3(0f, -0.2f, 0.3f);
        _defaultPelletPos = _pellet.transform.localPosition;
        _defaultPelletRot = _pellet.transform.localRotation;
    }

    private float _screenAspect = 1f;
    private float _distAhead = 1.84f;
    private void Start()
    {
        //SetSlingshotInFrontOfCamera();
    }

    private void Update()
    {
        if(!_isShooting)
        {
            _pellet.transform.localPosition = _defaultPelletPos;
            _pellet.transform.localRotation = _defaultPelletRot;
        }
        if(Input.touchCount > 0)
        {
            RaycastHit hit;
            Touch touch = Input.GetTouch(0);
            Ray ray = _camera.ScreenPointToRay(touch.position);

            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                Debug.Log($"{hit.transform.name}");
                if(hit.transform.tag == "Pellet")
                {
                    Shoot();
                    _isShooting = true;
                }
            }
        }
    }

    static Pellet CreatePellet(Transform parent,Transform pelletInfo)
    {
        Transform pelletWorldTransform = Instantiate(pelletInfo, pelletInfo.position, pelletInfo.rotation, pelletInfo.parent);
        pelletWorldTransform.localScale = pelletInfo.localScale;
        pelletWorldTransform.SetParent(parent, false);
        pelletWorldTransform.gameObject.tag = "Pellet";
        pelletWorldTransform.transform.position = new Vector3(0, 0f, 0.3f);

        return pelletWorldTransform.gameObject.AddComponent<Pellet>();
    }

    void Shoot()
    {
        _pellet.ShootWithSpeedAtCurrentRotation(5f);
    }

}
