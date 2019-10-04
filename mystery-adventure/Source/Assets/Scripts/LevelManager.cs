using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);        
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

    
    /*
    //gameObjects used as scenes
    public float sec = 14f;
    void Start()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);

        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);

        gameObject.SetActive(true);
        //Do Function here...
    }*/



   /* I would implement this with an abstract base class Interactable which inherits from MonoBehaviour
and has an abstract method public abstract void Interact(Player player).

Any object the player can interact with would then have a component which extends that abstract base-class
 and provides an object-specific interaction method.

To call that method form the player-class, use:

Interactable interactable = otherObject.GetComponent<Interactable>();
if (interactable != null) interactable.Interact(this);

    GetComponent also returns components which inherit from the provided class, so it will give you any component
    which extends Interactable.

    Another option is to use Unity messages. When the player tries to interact with an object, call
    otherObject.SendMessage("Interact", this) to send an "Interact" message to all components of the object.
This will call a method "Interact" on any component of that object which has one.The nice thing about this is
that you can have any number of components on an object which handle interactions.*/
}
