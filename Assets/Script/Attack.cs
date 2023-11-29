using System;
using System.Timers;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canAttack;
    private Timer attackTimer;
    private void Start()
    {
        attackTimer = new Timer(1000);
        attackTimer.Elapsed += OnTimerElapsed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canAttack) return;
        if (collision.CompareTag("Player"))
        { 
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);
            canAttack = false;
        }

    }
    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        CanAttack();
        attackTimer.Stop();
    }
    private void CanAttack()
    {
        canAttack = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (!canAttack) return;

        if (other.CompareTag("Player"))
        { 
            var damageable = other.GetComponent<Damageable>();
            damageable.TakeDamage(1);
            canAttack = false;
        }
    }
}
