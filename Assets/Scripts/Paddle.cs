using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool m_autoPlay = false;

	private Ball m_ball;

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(8.0f, 0.5f, 0.0f);
		m_ball = GameObject.FindObjectOfType<Ball> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (!m_autoPlay)
			MoveWithMouse ();
		else
			AutoPlay();
	}

	void MoveWithMouse()
	{
		float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16.0f, 0.5f, 15.5f);

		this.transform.position = new Vector3(mousePosInBlocks, transform.position.y, transform.position.z);
	}

	void AutoPlay()
	{
		transform.position = new Vector3 (m_ball.transform.position.x, transform.position.y, transform.position.z);
	}
}
