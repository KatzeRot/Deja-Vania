using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Image prefabHeart;
    [SerializeField] RectTransform panelHealth;
    int health;
    int lastHealth;
    private Image[] heartsNumber;
    
    // Use this for initialization
    void Start () {
        health = player.GetComponent<Player>().GetHealth();
        heartsNumber = new Image [health];
        lastHealth = health;
        print(heartsNumber.Length);
        for(int i = 0; i < heartsNumber.Length; i++) {
            Image heart = Instantiate(prefabHeart, panelHealth.transform);
            heartsNumber[i] = heart;
        }
	}
	
	// Update is called once per frame
	void Update () {
        health = player.GetComponent<Player>().GetHealth();
        if (lastHealth != health) {
            if(lastHealth > health) {
                Destroy(heartsNumber[health].gameObject);
                lastHealth = health;
            }else{ 
                for (int i = lastHealth; i < health; i++) {
                    Image heart = Instantiate(prefabHeart, panelHealth.transform);
                    heartsNumber[i] = heart;
                }
                lastHealth = health;
            }

            
        }
	}
}
