﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARock : MonoBehaviour
{
    public EnemyController enemyController;
    public Animator animator;

    public AudioSource audSource;
    public AudioClip idleClip;
    public AudioClip attackClip;
    private void Start()
    {
        float multiplier = PlayerData.currentDepth / 20 + 1;
        int realMultiplier = (int)multiplier;

        if (multiplier > 1)
        {
            enemyController.health *= realMultiplier;
            enemyController.baseDamage *= realMultiplier;
        }

        enemyController.speed = Random.Range(enemyController.speed - 1f, enemyController.speed + 1f);
        StartCoroutine(RockIA());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterCollision.instance.PlayerTakeDamage(enemyController.baseDamage);
        }
    }

    public IEnumerator RockIA()
    {
        animator.speed = 1f;
        audSource.clip = idleClip;
        audSource.Stop();
        audSource.Play();
        yield return new WaitForSeconds(Random.Range(enemyController.delayBetweenAttacks -0.5f, enemyController.delayBetweenAttacks + 0.5f));
        animator.speed = 2f;
        audSource.clip = attackClip;
        audSource.Stop();
        audSource.Play();

        Vector2 positionToMoveTo = CharacterManager.instance.transform.position;

        while(Vector2.Distance(positionToMoveTo, transform.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToMoveTo, enemyController.speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(RockIA());
    }
}
