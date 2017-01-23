using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 m_paddleToBallVector;
    private Rigidbody2D m_rigidBody;
    private bool m_isGameStarted;
    private Paddle m_paddle;
	private AudioSource m_audioSource;

	// Use this for initialization
	void Start () {
        m_paddle = GameObject.FindObjectOfType<Paddle>();

        m_paddleToBallVector = this.transform.position - m_paddle.transform.position;
        m_rigidBody = GetComponent<Rigidbody2D>();
		m_audioSource = GetComponent<AudioSource> ();
        m_isGameStarted = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_isGameStarted == false)
        {
            this.transform.position = m_paddle.transform.position + m_paddleToBallVector;

            if (Input.GetMouseButton(0))
            {
                m_rigidBody.velocity = new Vector2(2.0f, 10.0f);
                m_isGameStarted = true;
            }
        }
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (m_isGameStarted)
			m_audioSource.Play ();
	}
}
