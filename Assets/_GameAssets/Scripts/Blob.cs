using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour {
    [SerializeField] GameObject player;
    private SpriteRenderer sR;
    private float detectDistance = 9f;
    float dist;
    //[SerializeField] float speed;
    [SerializeField] float attackDistance;
    private Animator blobAnimator;
    //private float actualSpeed;
    bool status = true; //Determina si el personaje esta vivo

    [SerializeField] Transform cannon;
    [SerializeField] GameObject prefabProyectil;

    private const int TOTALHEALTH = 2; //Vida TOTAL que tiene
    private int health = TOTALHEALTH; //Vida actual que tiene

    [SerializeField] float power;
    private float attackCultdown;
    [SerializeField] float valueCultDown;

    // Use this for initialization
    void Start() {
        sR = GetComponent<SpriteRenderer>();
        blobAnimator = GetComponent<Animator>();
        attackCultdown = 0;

    }	
	// Update is called once per frame
	void Update () {
        print(attackCultdown);
        dist = Vector2.Distance(player.transform.position, transform.position);
        if (attackCultdown > 0) {
            attackCultdown -= valueCultDown;
        }
        if (IsAlive()){
            if (transform.position.x < player.transform.position.x) {
                sR.flipX = true;
                power *= -1;
                Attack();
            } else {
                sR.flipX = false;
                Attack();
            }
        }
    }
    void Attack() {
        if (dist <= attackDistance) {
            print("EL BLOB VE AL PLAYER");
            blobAnimator.SetBool("Attacking", true);
            if (attackCultdown <= 0) {
                attackCultdown = 10;
                GameObject newProyectil = Instantiate(prefabProyectil, cannon.transform.position, Quaternion.identity);
                if(attackCultdown <= 10) {
                    //newProyectil.transform.Translate(power * Time.deltaTime, 0, 0);
                    newProyectil.GetComponent<Rigidbody2D>().AddForce(Vector2.left * power * Time.deltaTime);
                    print("Dispara bolas");
                } else {
                    //Destroy(newProyectil.gameObject);
                }
            }
        } else {
            blobAnimator.SetBool("Attacking", false);     
        }
    }
    private void Die() {
        status = false;
        blobAnimator.SetBool("Dying", true);
        if (this.blobAnimator.GetCurrentAnimatorStateInfo(0).IsName("BlobDeath")) {
            Destroy(this.gameObject);
        }
    }
    private bool IsAlive() {
        bool status = true;
        if (health < TOTALHEALTH) {
            Die();
        }
        return status;
    }
    public void TakeDamage() {
        player.GetComponent<Player>().SwordHitSound();
        health--;

    }
}
