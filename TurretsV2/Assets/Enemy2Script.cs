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

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        RB = GetComponent<Rigidbody2D>();
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
}
