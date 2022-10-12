using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


public static class ARFoundationRemoteUtils
{
    // 카메라의 위치 정보를 반환하는 함수
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
        // 오브젝트의 위치를 맞추고 GameManager의 PlayerPos에 적용
        if (cameraPose.HasValue)
        {
            transform.position = cameraPose.Value.position;
            transform.rotation = cameraPose.Value.rotation;
            GameManager.Instance.PlayerPos = transform.position;
            GameManager.Instance.PlayerRot = transform.rotation;
        }
    }
}