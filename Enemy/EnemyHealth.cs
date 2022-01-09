using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Add amount to maxHitPoint when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int courrentHitPoints = 0;
    Enemy enemy;
    void OnEnable()
    {
        courrentHitPoints = maxHitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        courrentHitPoints--;
        if (courrentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
