﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningOrb : MonoBehaviour
{
    public float damagePerTick;
    public List<Collider2D> enemies = new List<Collider2D>();
    float j = 0;
    public float duration;
    public float delayBetweenHits;

    public AudioSource audSource;
    public AudioClip audClip;

    private void Start()
    {
        StartCoroutine(DamageOverTime());
        audSource.PlayOneShot(audClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Add(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision);
        }
    }
    public IEnumerator DamageOverTime()
    {
        yield return new WaitForSeconds(delayBetweenHits);

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].CompareTag("Enemy") && enemies[i].GetComponent<BoxCollider2D>())
            {
                enemies[i].GetComponent<EnemyController>().TakeDamage(GetComponent<Damager>().damage * Time.deltaTime);
            }
        }

        j += Time.deltaTime;

        if (j < duration) StartCoroutine(DamageOverTime());
        else Destroy(this.gameObject);
    }
}
