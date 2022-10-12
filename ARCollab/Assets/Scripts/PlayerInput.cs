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

public abstract class PlayerInput : MonoBehaviour, IInput
{
    private Ray ray;
    private int layerMask;

    public float distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (true)
        {
            Tab();
        }

        if (true)
        {
            Drag();
        }
    }

    /// <summary>
    /// 몇 번째 레이어인지 반환
    /// </summary>
    /// <param name="layerName">레이어 이름</param>
    /// <returns></returns>
    public int LayerInfo(string layerName)
    {
        // 나중에는 메서드가 아니라 class로 사용해야할 애니메이션 미리 연산해두고 쓸 것
        // ex ) 수업때 배웠던 AnimID class 같은
        layerMask = 1 << LayerMask.NameToLayer(layerName);

        return layerMask;
    }

    // 터치해서 만약 오브젝트가 있다면 true, 없다면 false 반환하는 형태로 가야할지
    public bool Tab()
    {
        return Tab(0);
    }
    public bool Tab(int layerMask)
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        if (Physics.Raycast(ray, distance, layerMask))
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
        // 이것도 레이를 그려야하나?
    }
}