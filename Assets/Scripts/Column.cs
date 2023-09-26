using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform checkerTop;
    public LayerMask playerLayer;

    private Vector3 velocity;
    private bool broke = false;

    private void Update()
    {
        if (Physics.CheckBox(checkerTop.position, new Vector3(1, 1, 1), Quaternion.identity, playerLayer))
        {
            broke = true;            
        }
        if (broke)
        {
            velocity.y -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }
}
