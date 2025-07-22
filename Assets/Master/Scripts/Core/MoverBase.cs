using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBase: MonoBehaviour, IMovable
{
    [SerializeField] protected float m_Speed = 2f;
   
    public virtual void Move()
    {
        transform.Translate(Vector2.left * m_Speed * Time.deltaTime);
    }

    protected virtual void Update()
    {
        Move();
    }
}
