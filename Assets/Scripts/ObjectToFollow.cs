using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToFollow : MonoBehaviour {

    public GameObject toFollow;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - toFollow.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (toFollow == null) Destroy(gameObject);
        else transform.position = toFollow.transform.position + offset;
		
	}
}
