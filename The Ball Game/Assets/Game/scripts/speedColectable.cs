using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedColectable : MonoBehaviour
{
   public characterMovement player;
    public void Start()
    {
        player = GameObject.FindObjectOfType<characterMovement>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("activated");
            player.activateSpeeddd(true);
            Destroy(this.gameObject);
        }

    }
}
