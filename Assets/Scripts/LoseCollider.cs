using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager m_levelManager;

    void Start()
    {
        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        m_levelManager.LoadLevel("Lose Screen");
    }
}
