using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(this.gameObject.name + " existe");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D other)
	{
		print("espada STAY!");
	}
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "HellHound") {
            other.GetComponent<HellHound>().TakeDamage();
        } else if (other.gameObject.tag == "Proyectil") {
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "Enemy") {
            other.GetComponent<Blob>().TakeDamage();
        }
	}
}
