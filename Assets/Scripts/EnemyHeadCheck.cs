using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHeadCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.GetComponent<PlayerFootCheck>()){
            rb.velocity = new Vector2(rb.velocity.y, 4f);
        }
    }
}
