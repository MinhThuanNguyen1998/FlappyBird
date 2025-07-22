using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MoverBase
{
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// Destroy pipe when it collides
    /// </summary>

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Reset"))
        {
            //Debug.Log("OnTriggerEnter2D");
            Destroy(gameObject);
        }
    }


}
