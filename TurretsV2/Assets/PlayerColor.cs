using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private PlayerScript PS;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.PI.playerIndex == 0)
        {
            SR.color = Color.red;
        }
        else if (PS.PI.playerIndex == 1)
        {
            SR.color = Color.blue;
        }
        else if (PS.PI.playerIndex == 2)
        {
            SR.color = Color.green;
        }
        else if (PS.PI.playerIndex == 3)
        {
            SR.color = Color.yellow;
        }
    }
}
