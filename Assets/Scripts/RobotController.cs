using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Vector3 m_MovementDirection;
    Vector3 m_TargetMovementDirection;

    [SerializeField]
    Transform m_NeckIKTarget;

    Vector3 initialPosition;

    [SerializeField]
    LegTargetController[] m_LegIKTargets;

    // Start is called before the first frame update
    void Start()
    {
        //todo: fix for cases where there are more than 1 dog in the scene
        m_LegIKTargets = GameObject.FindObjectsOfType<LegTargetController>();
        initialPosition = m_NeckIKTarget.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        Move();
        MoveNeck();
    }

    void Move()
    {
        transform.Translate(m_TargetMovementDirection * Time.deltaTime * 5.0f);

        foreach(LegTargetController legIK in m_LegIKTargets)
        {
            legIK.SetSpeed(m_TargetMovementDirection.x);
        }
    }

    void MoveNeck()
    {
        float y = Mathf.Sin(3.5f * m_TargetMovementDirection.x * Time.deltaTime) * 0.125f;

        m_NeckIKTarget.localPosition = initialPosition + new Vector3(0, y, 0);
    }

    void ReadInput()
    {
        m_TargetMovementDirection.x = Input.GetAxis("Horizontal");
    }
}
