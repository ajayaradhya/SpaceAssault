using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHitEffect : MonoBehaviour {

    [SerializeField] GameObject terrainHitEffect;
    private ParticleSystem PSystem;

    private List<ParticleCollisionEvent> CollisionEvents;

    void Start()
    {
        PSystem = GetComponent<ParticleSystem>();
        CollisionEvents = new List<ParticleCollisionEvent>(8);
    }

    void OnParticleCollision(GameObject other)
    {
        if(PSystem == null)
        {
            return;
        }

        int collCount = PSystem.GetSafeCollisionEventSize();

        if (collCount > CollisionEvents.Count)
        {
            CollisionEvents = new List<ParticleCollisionEvent>(collCount);
        }

        int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);
        for (int i = 0; i < eventCount; i++)
        {
            //TODO: Do your collision stuff here. 
            // You can access the CollisionEvent[i] to obtaion point of intersection, normals that kind of thing
            // You can simply use "other" GameObject to access it's rigidbody to apply force, or check if it implements a class that takes damage or whatever
            Instantiate(terrainHitEffect, CollisionEvents[i].intersection, Quaternion.identity);
        }
    }
}
