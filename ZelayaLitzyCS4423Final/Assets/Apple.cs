using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
      void OnTriggerEnter2D(Collider2D other)
     {
         if(other.GetComponent<Libriarian>() != null){
             other.GetComponent<Libriarian>().PickUpApple();
             Destroy(this.gameObject);


         }

     }
}
