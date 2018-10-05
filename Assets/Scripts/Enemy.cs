using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hit = 2;

    ScoreBoard scoreBoard;
    

    // Use this for initialization
    void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnParticleCollision(GameObject other)
    {
        print("enemy was hit : " + gameObject.name + " by " + other.name);
        ProcessHit();
        if(hit <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hit -= 1;
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        var fx = Instantiate(enemyDeathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = gameObject.transform.parent;
        Destroy(gameObject);
    }
}
