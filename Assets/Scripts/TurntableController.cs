using System;
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
    float m_CameraDistanceFromObject = 2.5f;
    
    Transform m_CameraTransform;

    [SerializeField]
    [Range(0.0f, 180.0f)]
    float m_CameraFOV = 60.0f;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    float m_CameraRotation;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    float m_ObjectRotation;
    
    
    void Awake()
    {
        if (m_RenderCamera != null)
        {
            m_CameraTransform = m_RenderCamera.gameObject.transform;
        }
    }
    
    void Update()
    {
        if (m_CameraTransform != null)
        {
            // calculate camera position around object
            float rotRad = m_CameraRotation * Mathf.Deg2Rad; 
            float xPos = m_CameraDistanceFromObject * Mathf.Sin(rotRad);
            float zPos = m_CameraDistanceFromObject * Mathf.Cos(rotRad);

            // set camera position
            m_CameraTransform.position = new Vector3(xPos, m_CameraHeightY, zPos);
            // set camera rotation
            m_CameraTransform.LookAt(m_TargetObject);
        }

        // rotate object
        m_TargetObject.eulerAngles = new Vector3(0, m_ObjectRotation, 0);
        // adjust camera FOV
        m_RenderCamera.fieldOfView = m_CameraFOV;
    }

    public void RotateObjectBy(float rotationValue)
    {
        m_ObjectRotation += rotationValue;
    }
}
