using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class movementAgent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 m_Speed;
    [FormerlySerializedAs("m_Target")] [SerializeField]
    private Vector3 m_Position;
    [SerializeField]
    private Vector3 M_Position;
    private Vector3 Distance_vector;
    private float distance;
    private float Mass = (float)0.018;
    private float param;
    private Vector3 acceleration;
    
    public GameObject target;
    void Start()
    {
        //Console.WriteLine("Введите координаты большого и малого тел:\n\r");
        //string[] R_vector = Console.ReadLine().Split();
        //string[] r_vector = Console.ReadLine().Split();
        m_Position = new Vector3(5, 5, 0);//(Convert.ToSingle(r_vector[0]), Convert.ToSingle(r_vector[1]), Convert.ToSingle(r_vector[2]));
        M_Position = new Vector3(0, 0, 0);//(Convert.ToSingle(R_vector[0]), Convert.ToSingle(R_vector[1]), Convert.ToSingle(R_vector[2]));
        distance = (M_Position - m_Position).magnitude;
        Distance_vector = M_Position - m_Position;
        param = 667 * Mass / (distance * distance);//(Distance_vector.magnitude * distance); //G x Mass / (R-r)^2 * |R-r|
        acceleration = (M_Position - m_Position)*param/distance;
        m_Speed = new Vector3(0,0,-1);//new Vector3((float)Math.Sqrt(acceleration.x*distance), (float)Math.Sqrt(acceleration.y*distance), (float)Math.Sqrt(acceleration.z*distance));
        Console.WriteLine(acceleration);
    }

    
    
    // Update is called once per frame
    void Update()
    {
        float dTime = Time.deltaTime;
        Vector3 delta = m_Speed*dTime + acceleration * (dTime * dTime / 2);
        m_Speed += acceleration * dTime;
        m_Position += delta;
        acceleration = (M_Position - m_Position);
        param = (float)(667 * Mass / Math.Pow((M_Position - m_Position).magnitude, 3));
        acceleration *= param;

        transform.Translate(delta);
        
        //transform.RotateAround(-1*target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}

