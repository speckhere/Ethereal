using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    private Animator animator;
    private bool playerNear;
    private bool interacted;

   void Start() 
   {
       animator = this.gameObject.GetComponent<Animator>();
       interacted = false;
   }   
   void Update()
    {
        if(!interacted && playerNear)
        { 
            if(Input.GetKey("e") && playerNear)
            {
                animator.SetTrigger("interacted");
                interacted = true;
                Debug.Log("HOLY SHIT GOLD!!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        playerNear = true;
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        playerNear = false;
    }
}
