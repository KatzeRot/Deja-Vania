﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoldCrown : MonoBehaviour {
	[SerializeField] Text finalText;
	[SerializeField] Button finalButton;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player"){
            SceneManager.LoadScene(2);
			//print("Tocado");
			//finalText.gameObject.SetActive(true);
			//finalButton.gameObject.SetActive(true);
			//Destroy(this.gameObject);
		}
	}
}
