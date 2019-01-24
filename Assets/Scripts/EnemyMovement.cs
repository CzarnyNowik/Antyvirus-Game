using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D rigBody;
    public float direction, speed;
    public LayerMask rightSide, leftSide, centerSide,Ground;


	void Start () {
        rigBody = GetComponent<Rigidbody2D>();
	}


    private void FixedUpdate()
    {
        rigBody.velocity = new Vector2(speed*Time.deltaTime*direction,rigBody.velocity.y);       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        direction = (transform.localScale.x > 0) ? 1 : -1;
        float otherLayer = Mathf.Pow(2, other.gameObject.layer);
        if (otherLayer == leftSide.value || otherLayer == Ground.value) Flip(true);
        if (otherLayer == rightSide.value) Flip(false);
        if (otherLayer == centerSide.value) Flip();
    }

    private void Flip(bool goRight)
    {
        if( (goRight == true && direction < 0 ) || (goRight == false && direction > 0))
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            direction *= -1;
            transform.localScale = theScale;
        }

    }

    private void Flip()
    {
        int random = Random.RandomRange(-5, 5);
        random = (random >= 0) ? 1 : -1;

            Vector3 theScale = transform.localScale;
            theScale.x *= random;
            direction *= random;
            transform.localScale = theScale;
    }


}
