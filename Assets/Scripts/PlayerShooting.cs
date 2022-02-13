using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private bool allowFire = true;
    public float bulletPerSecond = 5f;
    public Animator animator;

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
