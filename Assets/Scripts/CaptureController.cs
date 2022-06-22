using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(TurntableController))]
public class CaptureController : MonoBehaviour
{
    TurntableController m_TurntableController;

    float m_IncrementValue = 0.0f;
    float m_RotationValue = 1.0f;
    float m_SpeedValue;
    float m_RotationModValue;

    public enum ModValue
    {
        None,
        Double,
        Half,
        Quarter,
    }

    [SerializeField]
    ModValue m_SpeedModifcation = ModValue.None;

    [SerializeField]
    int m_NumberOfFramesToWait = 1;

    const float k_FullRotation = 360.0f;
    const float k_SpeedNone = 1.0f;
    const float k_SpeedDouble = 2.0f;
    const float k_SpeedHalf = 0.5f;
    const float k_SpeedQuarter = 0.25f;
    
    void OnEnable()
    {
        m_TurntableController = GetComponent<TurntableController>();

        switch (m_SpeedModifcation)
        {
            case ModValue.None:
                m_SpeedValue = k_SpeedNone;
            break;
            case ModValue.Double:
                m_SpeedValue = k_SpeedDouble;
            break;
            case ModValue.Half:
                m_SpeedValue = k_SpeedHalf;
            break;
            case ModValue.Quarter:
                m_SpeedValue = k_SpeedQuarter;
            break;
        }

        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        while(m_IncrementValue < k_FullRotation)
        {
            // calculate rotation value
            m_RotationModValue = m_RotationValue * m_SpeedValue;
            // set object rotation
            m_TurntableController.RotateObjectBy(m_RotationModValue);
            m_IncrementValue += m_RotationModValue;
            yield return null;
        }

        // exit playmode and stop recording after full rotation
        if (m_IncrementValue >= k_FullRotation)
        {
            for (int i = 0; i < m_NumberOfFramesToWait; i++)
            {
                yield return new WaitForEndOfFrame();
            }

            EditorApplication.ExitPlaymode();
        }
    }
}
