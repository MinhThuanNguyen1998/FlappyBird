using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MoverBase
{
    
    [SerializeField] protected Transform m_EndPoint;
    private Vector3 m_OriginPosX;
    private void Start()
    {
        m_OriginPosX = transform.position;
    }
    
    protected override void Update()
    {
        base.Update();
        if (transform.position.x < m_EndPoint.position.x)
        {
            transform.position = m_OriginPosX;
        }
    }


}
