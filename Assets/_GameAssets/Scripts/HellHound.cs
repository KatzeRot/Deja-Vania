using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour {
    [SerializeField] GameObject player;
    private SpriteRenderer sR;
    private float detectDistance = 9f;
    float dist;
    [SerializeField] float speed;
    [SerializeField] float attackDistance;
    private Animator hellHoundAnimator;
    private float actualSpeed;
    bool status = true; //Determina si el personaje esta vivo

    [SerializeField] ParticleSystem deathEffect;

    private int damage = 1; //Daño que provoca
    private const int TOTALHEALTH = 1; //Vida TOTAL que tiene
    private int health = TOTALHEALTH; //Vida actual que tiene
    [SerializeField] Camera mainCamera;


    // Use this for initialization
    void Start () {
        sR = GetComponent<SpriteRenderer>();
        hellHoundAnimator = GetComponent<Animator>();
        //speed = 3.5f;
        float actualSpeed = speed;
        //detectDistance.
        
    }
	
	// Update is called once per frame
	void Update () {
        if(IsAlive() == true) {
            dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < detectDistance) {
                hellHoundAnimator.SetBool("Walking", true);
                if (transform.position.x < player.transform.position.x) {
                    sR.flipX = true;
                    transform.Translate(new Vector3(actualSpeed * Time.deltaTime, 0, 0));
                    Attack();
                } else {
                    sR.flipX = false;
                    transform.Translate(new Vector3(-actualSpeed * Time.deltaTime, 0, 0));
                    Attack();
                }
            } else {
                hellHoundAnimator.SetBool("Walking", false);
            }
        }
        
	}
    void Attack() {
        if (dist <= attackDistance) {
            print("Distancia de Ataque");
            actualSpeed = 0;
            //hellHoundAnimator.SetBool("Attacking", true);
            //ataque
        } else {
            //hellHoundAnimator.SetBool("Attacking", false);
            actualSpeed = speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            print(this.gameObject.name + " toco al PLAYER");
            player.GetComponent<Player>().TakeDamage(damage);
            
            if (transform.position.x < player.transform.position.x) {
                player.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.right * 2, player.transform.position);
            } else {
                player.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.left * 2, player.transform.position);
            }
        }

    }
    private void Die() {
        status = false;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private bool IsAlive() {
        bool status = true;
        if(health < TOTALHEALTH) {
            Die();
        }
        return status;
    }
    

    public void TakeDamage() {
        player.GetComponent<Player>().SwordHitSound();
        health--;
        
    }
}
