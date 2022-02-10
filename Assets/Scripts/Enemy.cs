using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.setMaxHealth(maxhealth);
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) {
        int damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        checkDead();

    }
    void checkDead(){
        if (currentHealth<=0){
            Destroy(gameObject);
        }
    }
}
