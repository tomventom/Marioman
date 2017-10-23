using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public bool facingRight = true;
    public float jumpSpeed = 10;

    private float moveX;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    void FixedUpdate () {
        PlayerMove();
	}

    void PlayerMove() {
        moveX = Input.GetAxis("Horizontal");
        if (moveX > 0f && !facingRight) {
            facingRight = true;
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (moveX < 0f && facingRight) {
            facingRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    void Jump() {
        rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
    }

}
