using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item {
    [SerializeField] int value;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int TakeValue() {
        return value;
    }
}
