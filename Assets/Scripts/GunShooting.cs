using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    private float bulletForce;
    private bool allowFire = true;
    private float bulletPerSecond;
    public Animator animator;
    private PlayerStatus stat;
    private float bulletDamage;

    void Start(){
        stat = GetComponentInParent<PlayerStatus>();
        bulletPerSecond = stat.bulletPerSecond;
        bulletDamage = stat.bulletDamage;
        bulletForce = stat.bulletForce; 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && allowFire){
            allowFire = false;
            Shoot();
            StartCoroutine(FireRate());
            
        }
        
    }
    void Shoot(){

        GameObject bullet = Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
        bullet.GetComponent<Bullet>().bulletDamage = bulletDamage;
        bullet.GetComponent<Bullet>().setColor(stat.color);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        animator.SetTrigger("Shoot");
        rb.AddForce(firepoint.up*bulletForce,ForceMode2D.Impulse);
        Destroy(bullet,3f);
        
    }
    IEnumerator FireRate(){
        yield return new WaitForSeconds(1/bulletPerSecond);
        allowFire = true;
    }
    
}
