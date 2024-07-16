using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IEnemy
{

    public EnemyInfo enemyInfo;
    public Rigidbody2D rb;

    public void Move(){
        rb.velocity = new Vector2(0, Mathf.Sin(Time.time) * enemyInfo.speed);
    }

    public void Die(){
        // Throw not implemented exception
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(headCheck.transform.position.y);
    }

    void FixedUpdate(){
        Move();
    }
}
