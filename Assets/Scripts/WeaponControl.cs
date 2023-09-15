using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject hand;

    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    public GameObject bullet;
    public Transform firePoint;

    private float _fireCoolDown;
    public AudioClip gunShot;

    private void Update()
    {
        //Look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Fire Cooldown
        if (_fireCoolDown > 0)
        {
            _fireCoolDown -= Time.deltaTime;
        }

        //Shot
        if (Input.GetMouseButtonDown(0) && _fireCoolDown <= 0)
        {
            //Create Bullet
            Instantiate(bullet, firePoint.position, transform.rotation * Quaternion.Euler(90, 0, 0));

            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);

            //Animation
            GetComponent<Animator>().SetTrigger("shotTrigger");

            //Reset Cooldown
            _fireCoolDown = 0.25f;
        }
    }
}
