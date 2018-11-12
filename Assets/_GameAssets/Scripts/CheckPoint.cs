using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player") {
            //PLAYERPREFS
            GameController.StorePosition(collision.gameObject.transform.position);

            Destroy(this.gameObject);
        }
    }
}
