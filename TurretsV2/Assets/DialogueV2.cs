using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueV2 : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    //public TextMeshProUGUI ContinueDisplay;
    public string[] Sentences;
    public int Index;
    public float TypingSpeed;


    IEnumerator Type()
    {
        foreach (char letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += letter;

            yield return new WaitForSeconds(TypingSpeed);
            //StartCoroutine(PressA());
        }

        // Start is called before the first frame update
        void Start()
        {

         StartCoroutine(Type());
 
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
