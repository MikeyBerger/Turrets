using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float Counter;
    public float Limit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Counter++;

        if(Counter >= Limit)
        {
            Destroy(this.gameObject);
        }
    }
}
