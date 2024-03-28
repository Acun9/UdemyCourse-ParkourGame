using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    public Vector3 offset; //drone bize d�zg�n bakm�yorsa offset ekleyerek �evirebiliriz

    public float speed = 1;
    public float followDistance = 10f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        //Look to player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);

        //Move to player
        if (Vector3.Distance(transform.position, player.position) >= followDistance) //a ile b aras�ndaki uzakl��� float t�r�nde verir
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1); //-1 ters gitti�i i�in
        }
        else
        {
            transform.RotateAround(player.position, transform.up, Time.deltaTime * speed * Random.Range(0.2f, 3f)); // a'n�n etraf�nda b ekseninde d�ns�n
        }
        
    }
}
