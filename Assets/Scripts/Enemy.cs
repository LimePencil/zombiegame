using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxhealth = 50;
    public float currentHealth = 50;
    public HealthBar healthBar;
    public GameObject UIabove;
    public float enemyBodyDamage = 10f;

    void Start()
    {
        healthBar.setMaxHealth(maxhealth);
        UIabove.SetActive(false);
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) {
        UIabove.SetActive(true);
        if (other.gameObject.tag == "Bullet"){
            float damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            checkDead();
        }
        else if (other.gameObject.tag == "Player"){
            float damage = other.gameObject.GetComponent<PlayerStatus>().playerBodyDamage;
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            checkDead();
        }
    }
    
    void checkDead(){
        if (currentHealth<=0){
            Destroy(gameObject);
        }
    }
}
