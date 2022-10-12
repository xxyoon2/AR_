using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


public static class ARFoundationRemoteUtils
{
    // ī�޶��� ��ġ ������ ��ȯ�ϴ� �Լ�
    public static Pose? GetCameraPose()
    {
        var states = new List<XRNodeState>();
        InputTracking.GetNodeStates(states);
        foreach (var state in states)
        {
            if (state.nodeType == XRNode.CenterEye)
            {
                if (!state.TryGetPosition(out var position))
                {
                    return null;
                }

                if (!state.TryGetRotation(out var rotation))
                {
                    return null;
                }

                return new Pose(position, rotation);
            }
        }

        return null;
    }
}
public class PlayerPosInfo : MonoBehaviour
{
    private void Update()
    {
        var cameraPose = ARFoundationRemoteUtils.GetCameraPose();
        // ������Ʈ�� ��ġ�� ���߰� GameManager�� PlayerPos�� ����
        if (cameraPose.HasValue)
        {
            transform.position = cameraPose.Value.position;
            transform.rotation = cameraPose.Value.rotation;
            GameManager.Instance.PlayerPos = transform.position;
            GameManager.Instance.PlayerRot = transform.rotation;
        }
    }
}