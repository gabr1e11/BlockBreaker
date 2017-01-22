using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int m_maxHits;
    public Sprite[] hitSprites;

    private int m_timesHit;
    private LevelManager m_levelManager;
    private SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start () {
        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_timesHit = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        m_timesHit++;
        
        if (m_timesHit == m_maxHits)
            Destroy(gameObject);
        else
            m_spriteRenderer.sprite = hitSprites[m_timesHit - 1];
    }

    void SimulateWin()
    {
        m_levelManager.LoadNextLevel();
    }

}
