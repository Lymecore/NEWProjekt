using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public List<Transform> locations;

    private int locationsIndex = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
       if(agent.remainingDistance <  0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    void IntializePatrolRoute()
    {
        foreach( Transform child in locations)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationsIndex].position;
        locationsIndex = (locationsIndex + 1) % locations.Count;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dr,Pill")
        {
            agent.destination = player.position;
            Debug.Log("TORA TORA TORA!!!");
        }
    }
   
    private void OnTriggerExit(Collider other) { 
        if(other.name == "Dr.Pill")
        {
            Debug.Log("Resume Patrol UwU");
        }
        

    }
}
