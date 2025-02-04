﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 50f;
    private float timeToDestroy = 2f;
    public float damage;
    public Vector3 target { get; set; }
    public bool hit { get; set; }
    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wolf"))
        {
            MonsterBase monster = other.GetComponentInParent<MonsterBase>(); 
            if (monster != null)
            {
                monster.PlayerAttack(damage);
            }
            Destroy(gameObject);
        }
    }
    public void SetDamage(float damagenew){ damage = damagenew; }
    public void SetSpeed(float speednew){ speed = speednew; }
}