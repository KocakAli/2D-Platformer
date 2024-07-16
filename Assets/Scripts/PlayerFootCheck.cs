using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootCheck : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
        Debug.Log("Foot check");
        if(other.GetComponent<EnemyHeadCheck>()){
                Destroy(transform.parent.gameObject);
        }
   }
}
