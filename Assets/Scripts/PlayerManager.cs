using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool _playerAlive = true;
    public GameObject deathEffect;
    public void Death()
    {
        if (_playerAlive)
        {
            _playerAlive = false;

            //Particle Effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}
