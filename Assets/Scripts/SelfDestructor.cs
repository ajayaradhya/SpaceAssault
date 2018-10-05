using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    [SerializeField] float selfDestructionTime = 3f;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, selfDestructionTime);
	}
}
