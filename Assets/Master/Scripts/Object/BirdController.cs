using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float m_FlapForce = 5f;
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        ResetAnim();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Flap();
        }
        else
        {
            m_Animator.SetFloat("FlyPower",0);
        }
    }
    /// <summary>
    /// Flaps the bird when the space key is pressed
    /// </summary>
    private void Flap()
    {
        //Debug.Log("Flap");
        if (GameManager.Instance.IsEndGame) return; // Prevent flapping if the game is over
        AudioManager.Instance.PlayFlyingSound(); 
        m_Rigidbody.velocity = Vector2.up * m_FlapForce;
        m_Animator.SetFloat("FlyPower", m_FlapForce);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       //Debug.Log("OnTriggerEnter: Increase score");
        UIManager.Instance.AddScore();                                  
    }
    /// <summary>
    /// End Game when the bird collides with an obstacle or the ground.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollidionEnter2D");
        m_Animator.SetBool("IsDead", true);
        GameManager.Instance.EndGame(); 
        AudioManager.Instance.PlayGameOverSound(); 
    }
    /// <summary>
    /// Resets the bird's state when the game starts or restarts.
    /// </summary>
    private void ResetAnim()
    {
        m_Animator.SetFloat("FlyPower", 0);
        m_Animator.SetBool("IsDead", false);
    }
} 
