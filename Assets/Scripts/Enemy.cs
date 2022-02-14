using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxhealth = 50;
    public float currentHealth = 50;
    public HealthBar healthBar;
    public float enemyBodyDamage = 10f;
    public GameObject canvas;
    public Rigidbody2D rb;
    public float offset;

    void Start()
    {
        healthBar.setMaxHealth(maxhealth);
        canvas.SetActive(false);
    }
    
    void Update(){
        canvas.GetComponent<RectTransform>().position = rb.position + new Vector2(0,-1*offset);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Bullet"){
            canvas.SetActive(true);
            float damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            checkDead();
        }
        else if (other.gameObject.tag == "Player"){
            canvas.SetActive(true);
            float damage = other.gameObject.GetComponent<PlayerStatus>().playerBodyDamage;
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            checkDead();
        }
    }
    
    void checkDead(){
        if (currentHealth<=0){
            Destroy(gameObject);
            Destroy(canvas);
        }
    }
}
