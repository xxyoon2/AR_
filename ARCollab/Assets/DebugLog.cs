using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugLog : MonoBehaviour
{
    private TextMeshProUGUI _debugLog;

    private void Awake()
    {
        _debugLog = GetComponent<TextMeshProUGUI>();
    }

    public void Show(string message)
    {
        _debugLog.text = message;
    }
}
