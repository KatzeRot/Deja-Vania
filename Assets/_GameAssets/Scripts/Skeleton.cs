using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
    [SerializeField] GameObject player;
    private SpriteRenderer sR;
    private float detectDistance = 9f;
    float dist;
    [SerializeField] float speed;
    [SerializeField] float attackDistance;
    private Animator skeletonAnimator;
    private float actualSpeed;
    bool status = true; //Determina si el personaje esta vivo
    int damage = 1;

    // Use this for initialization
    void Start () {
        sR = GetComponent<SpriteRenderer>();
        skeletonAnimator = GetComponent<Animator>();
        speed = 3.5f;
        float actualSpeed = speed;
        //detectDistance.
    }
	
	// Update is called once per frame
	void Update () {
        if(status == true) {
            dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < detectDistance) {
                skeletonAnimator.SetBool("Walking", true);
                if (transform.position.x < player.transform.position.x) {
                    sR.flipX = false;
                    transform.Translate(new Vector3(actualSpeed * Time.deltaTime, 0, 0));
                    Attack();
                } else {
                    sR.flipX = true;
                    transform.Translate(new Vector3(-actualSpeed * Time.deltaTime, 0, 0));
                    Attack();
                }
            } else {
                skeletonAnimator.SetBool("Walking", false);
            }
        }
        
	}
    void Attack() {
        if(dist <= attackDistance) {
            print("Distancia de Ataque");
            actualSpeed = 0;
            skeletonAnimator.SetBool("Attacking", true);
            //ataque
        } else {
            skeletonAnimator.SetBool("Attacking", false);
            actualSpeed = speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "P_AreaAttack") {
            print("Se ha muerto");
            Die();
        }
    }
    private void Die() {
        status = false;
        skeletonAnimator.SetBool("Dying", true);
    }

    private bool IsAlive() {
        throw new NotImplementedException();
    }
}
