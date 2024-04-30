using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCBehaviour : MonoBehaviour
{
    // Needs
    public Needs hungerNeed;
    public float hungerIncreaseRate = 0.05f;
    public float hungerDecreaseAmount = 0.2f;

    // Movement
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public int currentWaypointIndex = -1;


    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        hungerNeed = new Needs("Hunger", 0.5f, 1.0f, 0.8f, 1.0f);
        FindWaypoints();
        SetRandomDestination();
    }


    public void Update()
    {
        IncreaseHungerOverTime();
        float urgency = hungerNeed.CalculateNeed();
        Debug.Log($"Hunger Urgency: {urgency}");

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }


    }

    public void IncreaseHungerOverTime()
    {
        hungerNeed.NeedDegrade(hungerIncreaseRate * Time.deltaTime);
    }

    public void SatisfyHunger()
    {
        hungerNeed.NeedSatisfy(hungerDecreaseAmount);
    }

    void FindWaypoints()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];

        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
    }

    void SetRandomDestination()
    {
        if (waypoints.Length == 0)
        {
            Debug.Log("No Waypoints!");
            return;
        }

        int randomIndex = Random.Range(0, waypoints.Length);
        while (randomIndex == currentWaypointIndex)
        {
            randomIndex = Random.Range(0, waypoints.Length);
        }
        currentWaypointIndex = randomIndex;
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
