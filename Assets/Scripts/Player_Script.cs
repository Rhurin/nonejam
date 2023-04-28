using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {
  public Rigidbody2D rb;
  public float moveSpeed;
  public float dashSpeed;
  public float cooldownDuration;
  public float dashDuration;

  bool dashing = false;
  bool dashAvailable = true;
  float activeSpeed = 4f;
  Vector3 movement;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update() {
    //MOVIMENTAÇÃO E ESQUIVA
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    if (dashing == true) {
      activeSpeed = dashSpeed;
    } else {
      activeSpeed = moveSpeed;
    }

    rb.MovePosition(transform.position + movement.normalized * activeSpeed * Time.fixedDeltaTime);

    if (dashAvailable == false) {
      return;
    }

    if (Input.GetKeyDown(KeyCode.LeftShift) == true && dashing == false) {
      StartCoroutine(StartDash());
      StartCoroutine(StartCooldown());
    }

  }
  //COROUTINE DASH
  public IEnumerator StartDash() {
    dashing = true;
    yield return new WaitForSeconds(dashDuration);
    dashing = false;
  }
  public IEnumerator StartCooldown() {
    dashAvailable = false;
    yield return new WaitForSeconds(cooldownDuration);
    dashAvailable = true;
  }
}
