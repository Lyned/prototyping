using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour {

    [SerializeField]
   public GameObject CurrentRoom;

    [SerializeField]
    public GameObject NextRoom;

    public void OnMouseDown()
    {
        /*if (gameObject.GetComponent<Collider2D>())
        { }*/
            if(gameObject.tag == "ChangeRoom")
            {
                CurrentRoom.SetActive(false);
                NextRoom.SetActive(true);
                print("Room changed");
            }        
    }

    
   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("ChangeView"))
        {
            CurrentRoom.SetActive(false);
            NextRoom.SetActive(true);
            print("Room changed");
        }
    }*/
}
