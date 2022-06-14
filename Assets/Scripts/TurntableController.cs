using System;
using Unity.Mathematics;
using UnityEngine;


[ExecuteInEditMode]
public class TurntableController : MonoBehaviour
{

    [SerializeField]
    Transform m_TargetObject;

    [SerializeField]
    Camera m_RenderCamera;

    [SerializeField]
    float m_CameraHeightY;

    [SerializeField]
    float m_CameraDistanceFromTarget;

    /*
    [SerializeField]
    GameObject m_TestObject;
*/
    Transform m_CameraTransform;

    [SerializeField]
    [Range(0.0f, 180.0f)]
    float m_CameraFOV;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    float m_CameraRotation = 60.0f;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    float m_ObjectRotation;
    
    
    void Awake()
    {
        if (m_RenderCamera != null)
        {
            m_CameraTransform = m_RenderCamera.gameObject.transform;
        }
        else
        {
            Debug.LogError("Render Camera is not set!");
        }
    }

    
    void Update()
    {
        Vector3 cameraOffset = new Vector3(0, m_CameraHeightY, 0);
        if (m_CameraTransform != null)
        {
            float rotRad = m_CameraRotation * Mathf.Deg2Rad; 
            float xPos = m_CameraDistanceFromTarget * Mathf.Sin(rotRad);
            float zPos = m_CameraDistanceFromTarget * Mathf.Cos(rotRad);

            m_CameraTransform.position = cameraOffset + new Vector3(xPos, 0, zPos);
            m_CameraTransform.LookAt(m_TargetObject);
            //m_TargetObject.eulerAngles = new Vector3(0, m_ObjectRotation, 0);
        }

        /*
        float rotRad = m_CameraRotation * Mathf.Deg2Rad; 
        float xPos = m_CameraDistanceFromTarget * Mathf.Sin(rotRad);
        float zPos = m_CameraDistanceFromTarget * Mathf.Cos(rotRad);

        m_TestObject.transform.position = cameraOffset + new Vector3(xPos, 0, zPos);
        m_TestObject.transform.LookAt(m_TargetObject);
        */
        m_TargetObject.eulerAngles = new Vector3(0, m_ObjectRotation, 0);

        m_RenderCamera.fieldOfView = m_CameraFOV;


    }

    public void SetObjectRotation(float rotationValue)
    {
        m_ObjectRotation += rotationValue;
    }

}
