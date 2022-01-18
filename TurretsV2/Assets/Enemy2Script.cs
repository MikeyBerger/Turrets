using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D RB;
    public float Speed;
    public float Offset;
    private Vector2 Movement;
    private SpriteRenderer SR;
    private SpawnScript SS;

    IEnumerator SelfDestruct()
    {
        SS.Score++;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        SS = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnScript>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 FaceDir = Player.position - transform.position;
        float Angle = Mathf.Atan2(FaceDir.y, FaceDir.x) * Mathf.Rad2Deg;
        RB.rotation = Angle - Offset;
        FaceDir.Normalize();
        Movement = FaceDir;
    }
    private void FixedUpdate()
    {
        Mover(Movement);
    }

    void Mover(Vector2 Dir)
    {
        RB.MovePosition((Vector2)transform.position + (Dir * Speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SR.enabled = false;
            StartCoroutine(SelfDestruct());
            Destroy(collision.gameObject);
        }
    }
}
