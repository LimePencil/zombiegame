using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10f;
    public void setColor(Color color){
        GetComponent<SpriteRenderer>().color = color;
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "Bullet"){
            Destroy(gameObject);  
        }
        else{
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(),other.gameObject.GetComponent<Collider2D>());
        }
        
    }
}
