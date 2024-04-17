using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    public Vector3 offset; //drone bize düzgün bakmýyorsa offset ekleyerek çevirebiliriz

    public float speed = 1;
    public float followDistance = 10f;

    private float cooldown = 2f;
    public GameObject mesh;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();
        Shot();
    }
    private void FollowPlayer()
    {
        //Look to player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);

        //Move to player
        if (Vector3.Distance(transform.position, player.position) >= followDistance) //a ile b arasýndaki uzaklýðý float türünde verir
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1); //-1 ters gittiði için
        }
        else
        {
            transform.RotateAround(player.position, transform.up, Time.deltaTime * speed * Random.Range(0.2f, 3f)); // a'nýn etrafýnda b ekseninde dönsün
        }
        
    }
    private void Shot()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
        }
    }
}
