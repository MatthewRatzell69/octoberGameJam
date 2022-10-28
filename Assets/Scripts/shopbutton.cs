using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopbutton : MonoBehaviour
{
    //variable to hold the sprite 
    private string sprite;


    
    // Start is called before the first frame update
    void Start()
    {
        //get the name of the sprite variable currently being used 
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function built into unity that fires when something is clicked and dragged
    void OnMouseUp()
    {

        //send the name over to the game manager so it knows what the currently selected tower is iun the shop
        gameManager.monsterSelected = sprite;
        Debug.Log("Currently Selected Monster is " + sprite);

    }
}
