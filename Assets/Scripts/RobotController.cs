using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Vector3 m_MovementDirection;
    Vector3 m_TargetMovementDirection;

    [SerializeField]
    LegTargetController[] m_LegIKTargets;

    // Start is called before the first frame update
    void Start()
    {
        m_LegIKTargets = GameObject.FindObjectsOfType<LegTargetController>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        Move();
    }

    void Move()
    {
        transform.Translate(m_TargetMovementDirection * Time.deltaTime * 5.0f);

        foreach(LegTargetController legIK in m_LegIKTargets)
        {
            legIK.SetSpeed(m_TargetMovementDirection.x);
        }
    }

    void ReadInput()
    {
        m_TargetMovementDirection.x = Input.GetAxis("Horizontal");
    }
}
