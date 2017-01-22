using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(8.0f, 0.5f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16.0f, 0.5f, 15.5f);

        this.transform.position = new Vector3(mousePosInBlocks, transform.position.y, transform.position.z);
	}
}
