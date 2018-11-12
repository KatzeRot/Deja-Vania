using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    int damage = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            print("Player tocado");
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 650);
        }
    }
}
