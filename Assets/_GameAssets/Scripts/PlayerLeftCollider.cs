using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftCollider : MonoBehaviour {
    [SerializeField] GameObject player;
	
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            float[] impulseValues = collision.GetComponent<Enemy>().GiveImpulseToPlayer();
            float valueX = impulseValues[0];
            float valueY = impulseValues[1];
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(valueX, valueY));
        } 
    }
}
