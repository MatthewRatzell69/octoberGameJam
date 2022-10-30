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
                    Debug.Log("Placing Skeleton");
                    towerPrefabToPlace = skeleton;
                    gameManager.gold -=25;
                    break;
                    //thorns case may get removed but should stay in
                case "PotionShop":
                    Debug.Log("Placing Potion");
                    towerPrefabToPlace = potion;
                    gameManager.gold -=50;
                    break;
                case "DraculaShop":
                    Debug.Log("Placing Dracula");
                    towerPrefabToPlace = dracula;
                    gameManager.gold -=100;
                    break;
                case "GhostShop":
                    Debug.Log("Placing Ghost");
                    towerPrefabToPlace = ghost;
                    gameManager.gold -=75;
                    break;
                case "JackOLanternShop":
                    Debug.Log("Placing Jack O Lantern");
                    towerPrefabToPlace = jackOLantern;
                    gameManager.gold -=150;
                    break;
                case "SpiderShop":
                    Debug.Log("Placing Spider");
                    towerPrefabToPlace = spider;
                    gameManager.gold -=200;
                    break;
                //need to add all of the other cases for other towers
                default:
                    
                    break;
            }

            //turn off the open spaces sprite
            gameObject.GetComponent<SpriteRenderer>().sprite=null;
            //if monster can be placed, place it on this spot 
            tower = Instantiate(towerPrefabToPlace, transform.position, Quaternion.identity);
 

            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
