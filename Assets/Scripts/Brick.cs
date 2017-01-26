using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
	public static int TotalBricks = 0;
	public AudioClip m_crack;
	public AudioClip m_hit;
    public ParticleSystem m_smoke;

    private int m_timesHit;
    private LevelManager m_levelManager;
    private SpriteRenderer m_spriteRenderer;
	private bool m_isBreakable;

	// Use this for initialization
	void Start () {
		m_isBreakable = (this.tag == "Breakable");

		if (m_isBreakable)
			TotalBricks++;

        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_timesHit = 0;	
	}
	
    void OnCollisionEnter2D(Collision2D coll)
    {
		if (this.tag == "Breakable")
			HandleHits ();
    }

	void HandleHits()
	{
		int maxHits = hitSprites.Length + 1;

		m_timesHit++;

		if (m_timesHit == maxHits) {
			AudioSource.PlayClipAtPoint (m_crack, transform.position, 0.8f);

            PuffSmoke();

            TotalBricks--;
			Destroy (gameObject);
			m_levelManager.BrickDestroyed ();
		} else {
			AudioSource.PlayClipAtPoint (m_hit, transform.position, 1.0f);
			LoadSprites ();
		}
	}

    void PuffSmoke()
    {
        ParticleSystem smokePuff = GameObject.Instantiate(m_smoke, transform.position, Quaternion.identity) as ParticleSystem;
        var mainModule = smokePuff.main;
        mainModule.startColor = m_spriteRenderer.color;
    }

	void LoadSprites()
	{
		int spriteIndex = m_timesHit - 1;

        if (hitSprites[spriteIndex] != null)
            m_spriteRenderer.sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Sprite for position " + spriteIndex + " is not valid");
	}

    void SimulateWin()
    {
        m_levelManager.LoadNextLevel();
    }

}
