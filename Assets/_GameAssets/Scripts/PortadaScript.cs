using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaScript : MonoBehaviour {
    [SerializeField] RectTransform[] rt;
    [SerializeField] float speed = 10;
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    //ARREGLAR LO DE LAS NUBES
    private void Update() {
        float xPos;
        for (int i = 0; i <= rt.Length; i++) {
            xPos = 1 * Time.deltaTime * speed;
            if (rt[i].position.x + rt[i].rect.width < 2500) {
                rt[i].Translate(xPos, 0, 0);
            } else {
                rt[i].Translate(-2500, 0, 0);
            }
        }
    }
}
