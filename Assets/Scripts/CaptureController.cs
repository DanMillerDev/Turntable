using System;
using System.Collections;
using System.Collections.Generic;
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
    
    void OnEnable()
    {
        m_TurntableController = GetComponent<TurntableController>();

        switch (m_SpeedModifcation)
        {
            case ModValue.None:
                m_SpeedValue = 1.0f;
            break;
            case ModValue.Double:
                m_SpeedValue = 2.0f;
            break;
            case ModValue.Half:
                m_SpeedValue = 0.5f;
            break;
            case ModValue.Quarter:
                m_SpeedValue = 0.25f;
            break;
        }
    }

    void Update()
    {
        m_RotationModValue = m_RotationValue * m_SpeedValue;
        m_TurntableController.SetObjectRotation(m_RotationModValue);
        m_IncrementValue += m_RotationModValue;

        if (m_IncrementValue >= 360.0f)
        {
            EditorApplication.ExitPlaymode();
        }
    }
}