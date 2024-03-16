using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAnimController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("k"))
        {
            anim.Play("ShutDown");
        }

        if (Input.GetKeyDown("j"))
        {
            anim.Play("WakeUp");
        }

        if (Input.GetKeyDown("l"))
        {
            anim.Play("Destroyed");
        }

    }
}
