using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAgent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 m_Speed;
    [SerializeField]
    private Vector3 m_Target;
    private Vector3 M_Target;
    private float Mass = 1;
    private float param;
    private Vector3 acceleration;
    void Start()
    {
        m_Target = new Vector3(10f, 0f, 0f);
        M_Target = new Vector3(0f, 0f, 0f);
        param = (float)(667 * Mass / Math.Pow((M_Target - m_Target).magnitude, 3));
        acceleration = (M_Target - m_Target)*param;
        m_Speed = new Vector3(acceleration.y, -1 * acceleration.x, acceleration.z);
    }

    // Update is called once per frame
    void Update()
    {
        float dTime = Time.deltaTime;
        Vector3 delta = m_Speed * dTime + acceleration * (dTime * dTime) / 2;
        m_Speed += acceleration * dTime;
        m_Target += delta;
        param = (float)(667 * Mass / Math.Pow((M_Target - m_Target).magnitude, 3));
        acceleration = (M_Target - m_Target)*param;
        transform.Translate(delta);
    }
}

