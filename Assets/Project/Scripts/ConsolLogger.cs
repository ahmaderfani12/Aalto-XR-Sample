using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolLogger : MonoBehaviour
{
    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
        Logger.Instance.LogInfo("Consol log enables");
    }
    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logstring,string stackTrace, LogType type)
    {

        if(type == LogType.Error)
        {
            Logger.Instance.LogError(logstring);
        }

        if (type == LogType.Warning)
        {
            Logger.Instance.LogWarning(logstring);
        }

        if (type == LogType.Log)
        {
            Logger.Instance.LogInfo(logstring);
        }
    }
}
