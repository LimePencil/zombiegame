using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float bulletPerSecond = 5f;
    public float playerspeed = 5f;
    public float playerMaxHealth = 100f;
    private float playerCurrentHealth;
    public float playerBodyDamage = 20f;
    public float bulletDamage = 30f;
    public float bulletForce = 20f;
    public float healthBarOffset = 0.5f;
    public Color color;
    public HealthBar healthBar;
    
    void Start(){
        healthBar.setMaxHealth(playerMaxHealth);
        GetComponent<SpriteRenderer>().color = color;
        playerCurrentHealth = playerMaxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy"){
            float damage = other.gameObject.GetComponent<Enemy>().enemyBodyDamage;
            playerCurrentHealth -= damage;
            healthBar.setHealth(playerCurrentHealth);
        }
    }

}
