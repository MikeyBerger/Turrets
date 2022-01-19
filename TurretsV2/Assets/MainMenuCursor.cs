using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuCursor : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    public bool IsPressed;

    IEnumerator StopPress()
    {
        yield return new WaitForSeconds(2);
        IsPressed = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsPressed = true;
            //StartCoroutine(StopPress());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1" && IsPressed)
        {
            SceneManager.LoadScene("1PScene");
        }
        else if (collision.gameObject.tag == "P2" && IsPressed)
        {
            SceneManager.LoadScene("2PScene");
        }
        else if (collision.gameObject.tag == "P3" && IsPressed)
        {
            SceneManager.LoadScene("3PScene");
        }
        else if (collision.gameObject.tag == "P4" && IsPressed)
        {
            SceneManager.LoadScene("4PScene");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1" && IsPressed)
        {
            SceneManager.LoadScene("1PScene");
        }
        else if (collision.gameObject.tag == "P2" && IsPressed)
        {
            SceneManager.LoadScene("2PScene");
        }
        else if (collision.gameObject.tag == "P3" && IsPressed)
        {
            SceneManager.LoadScene("3PScene");
        }
        else if (collision.gameObject.tag == "P4" && IsPressed)
        {
            SceneManager.LoadScene("4PScene");
        }
    }

    
}
