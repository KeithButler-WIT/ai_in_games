// 5 Following a tracker in a better way

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject [] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    public float lookAhead = 10.0f;  // 1) Ammount by which NPC is allowed to be behind tracker

    GameObject tracker;
    
    void Start()
    {

        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder); 

        DestroyImmediate(tracker.GetComponent<Collider>());
        
        // tracker.GetComponent<Renderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        // 2) Do not let tracker move unless it is within the distance defined by lookAhead from the NPC
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead)
            return;
            
        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        tracker.transform.LookAt(waypoints[currentWP].transform);

        // tracker.transform.Translate(0, 0, 0.3f);
        tracker.transform.Translate (0, 0, (speed+20) * Time.deltaTime);
    }

    void Update()
    {

        ProgressTracker();

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate (0, 0, speed * Time.deltaTime);
    }
}

// Try different NPC speeds: 10, 20, 100
