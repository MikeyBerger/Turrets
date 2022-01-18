using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image Button1;
    public Image Button2;
    public Image Button3;
    public Image Button4;



    public Text TextDisplay;
    //public TextMeshProUGUI ContinueDisplay;
    public string[] Sentences;
    public int Index;
    public float TypingSpeed;


    IEnumerator CreateButtons()
    {
        yield return new WaitForSeconds(1000);
        Button1.enabled = true;
        yield return new WaitForSeconds(1500);
        Button2.enabled = true;
        yield return new WaitForSeconds(2000);
        Button3.enabled = true;
        yield return new WaitForSeconds(2500);
        Button4.enabled = true;
        //yield return new WaitForSeconds(4);
        //QualityText.text = "For a better gaming experience, I recommend using a dual-joystick controller";
    }

    IEnumerator Type()
    {
        foreach (char letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += letter;

            yield return new WaitForSeconds(TypingSpeed);
            //StartCoroutine(PressA());
        }

        // Start is called before the first frame update
#pragma warning disable CS8321 // Local function is declared but never used
        void Start()
#pragma warning restore CS8321 // Local function is declared but never used
        {
            Button1.enabled = false;
            Button2.enabled = false;
            Button3.enabled = false;
            Button4.enabled = false;
            StartCoroutine(CreateButtons());
        }

        // Update is called once per frame
        void Update()
        {
           // NextSentence();
        }

        void NextSentence()
        {
            if (Index < Sentences.Length - 1)
            {
                Index++;
                TextDisplay.text = "";
                StartCoroutine(Type());
            }
        }
    }
}
