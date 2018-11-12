using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    Rigidbody2D rb2D;
    Animator playerAnimator;
    SpriteRenderer playerSprite;

    enum StatusPlayer { Stop, RunningR, RunningL, Jumping, Enjuring }
    StatusPlayer status = StatusPlayer.Stop;

    [SerializeField] float radioOverlap = 0.1f;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] Image barraMagic;
    [SerializeField] Text statusPlayer;
    float magic = 1;

    //bool jumping;

    [Header("Atributtes")]
    private const int TOTALHEALTH = 3;
    private int health = TOTALHEALTH;
    private int puntuation = 0;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 10;
    //[SerializeField] int hearts;

    [Header("References")]
    [SerializeField] Text txtPuntuation;
    [SerializeField] Transform posFoot;

    // Use this for initialization
    void Start() {
        //health = totalHealth;
        statusPlayer.text = "StatusPlayer: " + status.ToString(); // Unica función de mostrar en pantalla el estado del player
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        txtPuntuation.text = "Score: " + puntuation;
        Vector2 position = GameController.GetPosition();
        this.transform.position = position;
    }
    private void Update() {
        print("TOCA EL PUTO SUELO?: " + IsInGround());
        if(status == StatusPlayer.Stop || status == StatusPlayer.RunningL || status == StatusPlayer.RunningR){
            if (Input.GetKeyDown(KeyCode.Space)) {
            magic -= 0.2f;
            print("Space PULSADO");
            }
        }
        if(IsInGround()){
            playerAnimator.SetBool("Falling", false);
            playerAnimator.SetBool("Jumping", false);
        }else{
            playerAnimator.SetBool("Falling", true);
            playerAnimator.SetBool("Jumping", false);
        }

        statusPlayer.text = "StatusPlayer: " + status.ToString(); // Unica función de mostrar en pantalla el estado del player        
            
        magic += 0.002f;
        barraMagic.fillAmount = magic;

        flipSprite();
        Die();
    }
    // Update is called once per frame
    void FixedUpdate () {
        MovePlayer();
	}
    private void MovePlayer() {
        float xPos = Input.GetAxis("Horizontal");
        float ySpeedActual = rb2D.velocity.y;
        if(Mathf.Abs(xPos) > 0.01f) {
            playerAnimator.SetBool("Running", true);
        } else {
            playerAnimator.SetBool("Running", false);   
        }

        if(status == StatusPlayer.Jumping){
            status = StatusPlayer.Stop;
            if (IsInGround()) {
                print("SALTO!");
                rb2D.velocity = new Vector2(xPos * speed, jumpForce);
            } else {
                rb2D.velocity = new Vector2(xPos * speed, ySpeedActual); // Esto sirve para que cuando el player salte pueda moverse en el aire
            }
        } else {
            rb2D.velocity = new Vector2(xPos * speed, ySpeedActual);
        }
    }
    private void IncreasePuntuation(int valuePuntuation) {
        puntuation += valuePuntuation;
        txtPuntuation.text = "Score: " + puntuation;
    }
    private void flipSprite() {
        if (Input.GetKeyDown(KeyCode.W)) {
            status = StatusPlayer.Jumping;
            playerAnimator.SetBool("Jumping", true);
            print("W PULSADA");
            //status = StatusPlayer.Stop;
        } else if (Input.GetKey(KeyCode.D)) {
            status = StatusPlayer.RunningR;
            playerSprite.flipX = false;
        }else if (Input.GetKey(KeyCode.A)) {
            status = StatusPlayer.RunningL;
            playerSprite.flipX = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        print("Tocaste " + collision.gameObject.name);

        if (collision.gameObject.name == "Coin10") {
            IncreasePuntuation(collision.gameObject.GetComponent<Coin>().TakeValue());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Heart") {
            if(health < TOTALHEALTH) {
                //hearts[health].enabled = true;
                health++;
                Destroy(collision.gameObject);
            }
        }
    }
    public void TakeDamage(int damage) {
        status = StatusPlayer.Enjuring;
        health -= damage;
        if(health <= 0){
            health = 0;
        }   
    }
    public bool Die() {
        bool isAlive = false;
        if (health == 0) {
            isAlive = true;
            print("MUERTO!!!");
        }
        return isAlive;
    }
    private bool IsInGround() {
        //status = StatusPlayer.Stop;
        bool inGround = false;
        Collider2D collider = Physics2D.OverlapCircle(posFoot.position, radioOverlap, floorLayer);
        if(collider != null) {
            inGround = true;
            
        }
        return inGround;
    }
    public int GetHealth() {
        return health;
    }
    //private bool IsInGround() {
    //    bool inGround = false;
    //    Collider2D[] cols = Physics2D.OverlapCircleAll(posFoot.position, radioOverlap);
    //    for(int i = 0; i < cols.Length; i++) {
    //        if (cols[i] != null && cols[i].gameObject.tag == "Ground") {
    //            //print("Los pies han tocado: " + cols[i].gameObject.name);
    //            inGround = true;
    //            break;
    //        }  
    //    }
    //    return inGround;
    //}
}
