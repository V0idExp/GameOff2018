using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject playerObject;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - playerObject.transform.position;
	}
	
	void LateUpdate () {
        transform.position = playerObject.transform.position + offset;
	}
}
