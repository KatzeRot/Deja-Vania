using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform rightLimit;
    public Transform leftLimit;
    bool goRight = true;
    [SerializeField] float speed = 2;
    float valueX = 1000;
    float valueY = 200;

    private float[] values;

    int damage = 1;

    private void Start() {
        transform.position = rightLimit.position;
    }
    private void Update() {
        if (goRight) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > rightLimit.position.x) {
                GetComponent<SpriteRenderer>().flipX = true;
                goRight = false;
            }
        } else {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if(transform.position.x < leftLimit.position.x) {
                GetComponent<SpriteRenderer>().flipX = false;
                goRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        print("ENEMY toca: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            //collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 650);
        }
    }
    public float[] GiveImpulseToPlayer() {
        values = new float[] {valueX, valueY};
        return values;
    }
}
