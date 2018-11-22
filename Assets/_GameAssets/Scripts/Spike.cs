using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            print(collision.gameObject.name + " PINCHADO HASTA MORIR");
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            //collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 650);
            collision.transform.Translate(0, 200 * Time.deltaTime, 0);
        }
    }
}
