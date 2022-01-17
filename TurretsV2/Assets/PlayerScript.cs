using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Vector2 MousePos;
    private Rigidbody2D RB;
    public Rigidbody2D Gun;
    public float Offset;
    public bool IsShooting = false;
    Vector2 RotateVector;
    Vector2 MoveVector;
    public float Speed;
    public PlayerInput PI;
    public Transform ShootPoint;
    public Transform Bullet;
    public Transform AudioClip;
    public float BulletForce;
    public bool P2;
    public bool P3;
    public bool P4;


    IEnumerator StopShooting()
    {
        yield return new WaitForSeconds(0);
        IsShooting = false;
    }

    IEnumerator StartShooting()
    {
        
        Transform BulletPrefab = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody2D BulletRB = BulletPrefab.GetComponent<Rigidbody2D>();
        BulletRB.AddForce(ShootPoint.up * BulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RB = GetComponent<Rigidbody2D>();
        Gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Rigidbody2D>();
        PI = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PI.playerIndex == 0)
        {
            gameObject.tag = "Player1";
        }
        else if (PI.playerIndex == 1)
        {
            gameObject.tag = "Player2";
        }
        else if (PI.playerIndex == 2)
        {
            gameObject.tag = "Player3";
        }
        else if (PI.playerIndex == 3)
        {
            gameObject.tag = "Player4";
        }

        //print(MousePos);
        /*
        Vector2 FaceDir = MousePos - Gun.position;
        float Angle = Mathf.Atan2(FaceDir.y, FaceDir.x) * Mathf.Rad2Deg;
        RB.MoveRotation(Angle - Offset);
        */
        RotateTurret();

        transform.Translate(new Vector2(MoveVector.x, MoveVector.y) * Speed);

        if (IsShooting)
        {
            StartCoroutine(StartShooting());
            IsShooting = false;

        }


    }

    void RotateTurret()
    {
        Gun.transform.up = new Vector2(RotateVector.x, RotateVector.y) * -1;
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsShooting = true;
            //print("Fire!!");
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        //MousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        RotateVector = ctx.ReadValue<Vector2>();  
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MoveVector = ctx.ReadValue<Vector2>();
    }
}
