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

    [SerializeField]
    private float _distAheadOffset = 0.5f;

    private void Awake()
    {
        _camera = GetComponentInParent<Camera>();
        _pelletLocalOrigin = Pellet.transform.localPosition;
        _pellet = CreatePellet(Pellet.transform);
        _slingshotPos = new Vector3(0f, -0.17f, 0f);
    }

    private float _screenAspect = 1f;
    private float _distAhead = 1.84f;
    private void Start()
    {
        UpdatePullbackVisuals();
        SetSlingshotInFrontOfCamera();
    }

    void SetSlingshotInFrontOfCamera()
    {
        _screenAspect = (float)Screen.height / (float)Screen.width;
        float percentage = _screenAspect / _camera.fieldOfView;
        _distAhead = Mathf.Atan(percentage * 100f) - _distAheadOffset;

        Vector3 localPos = transform.localPosition;
        localPos.z = _distAhead * _screenAspect;
        localPos.y = _slingshotPos.y;
        transform.localPosition = localPos;
    }

    static Pellet CreatePellet(Transform pelletInfo)
    {
        Transform pelletWorldTransform = Instantiate(pelletInfo, pelletInfo.position, pelletInfo.rotation, pelletInfo.parent);
        pelletWorldTransform.localScale = pelletInfo.localScale;
        pelletWorldTransform.parent = null;
        pelletWorldTransform.gameObject.tag = "Pellet";
        pelletWorldTransform.transform.position = new Vector3(999, 999, 999);

        return pelletWorldTransform.gameObject.AddComponent<Pellet>();
    }

    void UpdatePullbackVisuals()
    {

    }
}
