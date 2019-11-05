using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegTargetController : MonoBehaviour
{

    float m_Speed;

    float x, y, m_CurrentAngle;

    //For circular movement
    [SerializeField]
    float m_Radius = 1.5f;

    //For elipsoid movement
    float m_SemiMajorAxis = .55f;
    float m_SemiMinorAxis = 0.45f;

    float m_YOffset = 0.15f;

    Vector2 m_StartingPosition;

    public void SetSpeed(float speed)
    {
        if(speed == 0)
        {
            m_Speed = 0;
        }
        else
        {
            m_Speed = -(Mathf.PI * 2) / speed;
        }
    }

    private void Start()
    {
        m_StartingPosition = transform.localPosition + new Vector3(0, m_YOffset);
    }

    private void Update()
    {
        //Run();
        Walk();
    }

    void Walk()
    {
        m_CurrentAngle += Time.deltaTime * m_Speed;
        x = m_StartingPosition.x + m_SemiMajorAxis * Mathf.Cos(m_CurrentAngle);
        y = m_StartingPosition.y + m_SemiMinorAxis * Mathf.Sin(m_CurrentAngle);

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }

    //Circular motion for running looks better
    void Run()
    {
        m_CurrentAngle += Time.deltaTime * m_Speed;
        x = m_StartingPosition.x + m_Radius * Mathf.Cos(m_CurrentAngle);
        y = m_StartingPosition.y + m_Radius * Mathf.Sin(m_CurrentAngle);

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}
