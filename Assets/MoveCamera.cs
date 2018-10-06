using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField] float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var newPositionZOfCamera = transform.position.z + speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZOfCamera);
    }
}
