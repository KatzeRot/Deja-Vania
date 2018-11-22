using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovil : MonoBehaviour {
    bool status;
    private float speed;

    // Use this for initialization
    void Start () {
        status = true;
        speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(status == false) {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        } else {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "PlatformMovil") {
            print("TOCA MADERA!!");
            if(status == true) {
                status = false;
            } else {
                status = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
        if(collision.gameObject.gameObject.tag == "Player"){
            collision.gameObject.transform.parent = this.gameObject.transform;
        }else{
            
        }
    }
}
