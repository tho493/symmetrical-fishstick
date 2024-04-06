using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDiChuyen : MonoBehaviour
{
    [SerializeField]
    GameObject findPlayer;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveMent;

    public float x;
    public float y; 

    public float buletForce = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            Vector3 direction = findPlayer.transform.position - transform.position;
            float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            moveMent = direction;
        
    }
    private void FixedUpdate()
    {
        moveCharacter(moveMent);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
