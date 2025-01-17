﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss1 : MonoBehaviour
{
    public EnemyController enemyController;
    public Animator animator;
    public BoxCollider2D slimeCollider;
    public GameObject orb;

    public bool canMove;
    public bool canSpeed;

    public Vector2 positionToMoveTo;

    public float currentDelay = 0;
    public bool isIdle;

    public GameObject orbSpawnPoint;

    public AudioSource audSource;
    public AudioClip groundHitClip;

    private void Start()
    {
        float multiplier = PlayerData.currentDepth / 20 + 1;
        int realMultiplier = (int)multiplier;

        if (multiplier > 1)
        {
            enemyController.health *= realMultiplier;
            enemyController.baseDamage *= realMultiplier;
        }
    }
    private void Update()
    {
        currentDelay += Time.deltaTime;
        if (currentDelay > enemyController.delayBetweenAttacks) EnableSpeed();

        if (canMove)
        {
            if (canSpeed) transform.position = Vector2.MoveTowards(transform.position, positionToMoveTo, enemyController.speed * Time.deltaTime);
            currentDelay = 0;
        }
        else
        {
            positionToMoveTo = new Vector2(CharacterManager.instance.transform.position.x, CharacterManager.instance.transform.position.y - 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterCollision.instance.PlayerTakeDamage(enemyController.baseDamage);
        }
    }

    public void PlayGroundHit()
    {
        audSource.PlayOneShot(groundHitClip);
    }

    public void EnableSpeed()
    {
        canMove = true;
    }

    public void DisableSpeed()
    {
        canMove = false;
    }

    public void CanSpeed()
    {
        canSpeed = true;
    }

    public void CantSpeed()
    {
        canSpeed = false;
    }
    public void DisableBoxCollider()
    {
        slimeCollider.enabled = false;
    }

    public void enableBoxCollider()
    {
        slimeCollider.enabled = true;
    }

    public void SpawnOrb()
    {
        GameObject temp = Instantiate(orb, orbSpawnPoint.transform.position, Quaternion.identity, Spawner.instance.orbHolder.transform);
        temp.GetComponent<Boss1Orb>().enemyController = enemyController;
    }
}
