using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    //플레이어 좌표
    public GameObject TigerPrefab;

    private GameObject _Camera;
    RaycastHit hit;
    [SerializeField]
    private float distance = 3.0f;

    private void Start()
    {
        _Camera = GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTigerLocation();
    }

    private void CheckTigerLocation()
    {
        transform.position = new Vector3(0, _Camera.transform.position.y + 2, _Camera.transform.position.z + distance);
       
        Physics.Raycast(transform.position, Vector3.down, out hit);

        TigerPrefab.transform.position = hit.transform.position;
    }
}
