using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{    //reference to player
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        // grab ref to player
        player = GameObject.Find("Dr.Pill").GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dr.Pill")
        {
            player.coincount++;
            Destroy(this.gameObject);
        }
    }
}