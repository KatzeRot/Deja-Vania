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
		print("espada ENTER!");
	}
}
