using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Vector2 MousePos;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(MousePos);

        Vector2 FaceDir = MousePos - RB.position;
        float Angle = Mathf.Atan2(FaceDir.y, FaceDir.x) * Mathf.Rad2Deg;
        RB.MoveRotation(Angle);
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            print("Fire!!");
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        MousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
            
    }
}
