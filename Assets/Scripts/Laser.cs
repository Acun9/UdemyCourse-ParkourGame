using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, playerLayer;
    public GameObject deathEffect;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f + Mathf.Sin(Time.time)/80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        //Kill Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, playerLayer))
        {
            hit.transform.gameObject.GetComponent<PlayerManager>().Death();
        }
    }
}
