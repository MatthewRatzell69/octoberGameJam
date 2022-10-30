using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpot : MonoBehaviour
{
    //these variables are for all the different towers it could be 
    public GameObject skeleton;
    public GameObject potion;
    public GameObject dracula;
    public GameObject jackOLantern;
    public GameObject ghost;
    public GameObject spider;

    private GameObject towerPrefabToPlace;
    private GameObject tower;

    private Sprite originalSprite;
    private bool CanPlaceTower()
    {
        //if the openspot doesnt have a monster return true
        if (tower == null)
        {
            return true;
        }

        return false;
        
    }

    //function built into unity that fires when something is clicked and dragged
    void OnMouseUp()
    {
        
        if (CanPlaceTower())
        {
            //get the currently selected monster prefab from the game manager
            switch (gameManager.monsterSelected)
            {
                case "SkeletonShop":
                    if (gameManager.gold >= 25)
                    {
                        Debug.Log("Placing Skeleton");
                        towerPrefabToPlace = skeleton;
                        gameManager.gold -= 25;

                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }  
                    break;
                    //thorns case may get removed but should stay in
                case "PotionShop":
                    if (gameManager.gold >= 50)
                    {
                        Debug.Log("Placing Potion");
                        towerPrefabToPlace = potion;
                        gameManager.gold -= 50;

                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }
                    break;
                case "DraculaShop":
                    if (gameManager.gold >= 100)
                    {
                        Debug.Log("Placing Dracula");
                        towerPrefabToPlace = dracula;
                        gameManager.gold -= 100;

                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }
                    break;
                case "GhostShop":
                    if (gameManager.gold >= 75)
                    {
                        Debug.Log("Placing Ghost");
                        towerPrefabToPlace = ghost;
                        gameManager.gold -= 75;

                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }
                    break;
                case "JackOLanternShop":
                    if (gameManager.gold >= 150)
                    {
                        Debug.Log("Placing Jack O Lantern");
                        towerPrefabToPlace = jackOLantern;
                        gameManager.gold -= 150;

                        
                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }     
                    break;
                case "SpiderShop":
                    if(gameManager.gold >= 200)
                    {
                        Debug.Log("Placing Spider");
                        towerPrefabToPlace = spider;
                        gameManager.gold -= 200;

                        
                        tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
                    }
                    break;
                //need to add all of the other cases for other towers
                default:
                    
                    break;
            }

            //turn off the open spaces sprite
            //gameObject.GetComponent<SpriteRenderer>().sprite=null;
            
 

            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //get the sprite we need
        originalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPlaceTower())
        {
            //turn off the open spaces sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
        else
        {
            //turn off the open spaces sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
