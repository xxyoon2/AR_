using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    public int LayerInfo(string layerName);
    public bool Tab(int layerMask);
    public bool Tab();
    public void Drag();
}

public class PlayerInput : MonoBehaviour, IInput
{
    private Ray ray;
    private RaycastHit hit;
    private int layerMask;

    public float distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            if (Tab(0))
            {
                hit.transform.GetComponent<Tiger>()?.Die();
            }
        }
        // if(�巡������ �Ǵ�) { }
    }

    /// <summary>
    /// �� ��° ���̾����� ��ȯ
    /// </summary>
    /// <param name="layerName">���̾� �̸�</param>
    /// <returns></returns>
    public int LayerInfo(string layerName)
    {
        // ���߿��� �޼��尡 �ƴ϶� class�� ����ؾ��� �ִϸ��̼� �̸� �����صΰ� �� ��
        // ex ) ������ ����� AnimID class ����
        layerMask = 1 << LayerMask.NameToLayer(layerName);

        return layerMask;
    }

    // ��ġ�ؼ� ���� ������Ʈ�� �ִٸ� true, ���ٸ� false ��ȯ�ϴ� ���·� ��������
    public bool Tab()
    {
        return Tab(0);
    }

    public bool Tab(int layerMask)
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Drag()
    {
        // �̰͵� ���̸� �׷����ϳ�?
    }
}