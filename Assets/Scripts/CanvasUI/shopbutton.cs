using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopbutton : MonoBehaviour
{
    //variable to hold the sprite 
    private string spriteName;

    //what is used to hold the original sprite for each button
    private Sprite originalSprite;



    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        //get the name of the sprite variable currently being used 
        spriteName = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        originalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteName == gameManager.monsterSelected)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }

    //function built into unity that fires when something is clicked and dragged
    void OnMouseUp()
    {

        //send the name over to the game manager so it knows what the currently selected tower is iun the shop
        gameManager.monsterSelected = spriteName;
        Debug.Log("Currently Selected Monster is " + spriteName);

        //also make sure we change to the updated sprite

    }
}
