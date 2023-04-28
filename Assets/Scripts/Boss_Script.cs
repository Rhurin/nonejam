using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script : MonoBehaviour {

  public Rigidbody2D rb;
  public GameObject player;
  public Vector3 movement;
  public int maxHealth = 100;
  public int currentHealth;
  public HealthBar healthBar;


  SpriteRenderer spr;

  void Start() {
    rb = GetComponent<Rigidbody2D>();

    //vida boss
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
  }

  void Update() {

    //tomar dano teste
    if (Input.GetKeyDown(KeyCode.Space)) {
      TakeDamage(5);
    }

    //FLIP FOLLOW PLAYER
    if (transform.position.x < player.transform.position.x)
      GetComponent<SpriteRenderer>().flipX = true;
    else
      GetComponent<SpriteRenderer>().flipX = false;

    rb.transform.position = new Vector3(-4f, 0.5f, 0f);

  }

  //dano teste
  void TakeDamage(int damage) {
    currentHealth -= damage;

    healthBar.SetHealth(currentHealth);
  }


}
