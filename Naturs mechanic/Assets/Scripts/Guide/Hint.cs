using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
  
    public Text hintText;
    public enum mechanic {jump, climb, shoot, win };
    public mechanic mek = new mechanic { };

    // Start is called before the first frame update
    void Start()
    {
        hintText.text = " ";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && mek == mechanic.jump)
        {
            hintText.text = "JUMP";
        }
        else if (other.CompareTag("Player") && mek == mechanic.climb)
        {
            hintText.text = "CLIMB";
        }
        else if (other.CompareTag("Player") && mek == mechanic.shoot){
            hintText.text = "SHOOT";
        }
        else if (other.CompareTag("Player") && mek == mechanic.win)
        {
            hintText.text = "YOU'VE COMPLETED THE LEVEL";
        } 
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hintText.text = "";
    }




}
