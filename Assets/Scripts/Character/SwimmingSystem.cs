using UnityEngine;

public class SwimmingSystem : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement movement;
    private bool isSwimming;
    private bool interacted;
    

   void Start() 
   {
       animator = this.gameObject.GetComponent<Animator>();
       isSwimming = false;
       movement.runSpeed = 40f;

   }   
   
   void Update()
    {
        if(isSwimming)
        { 
            movement.runSpeed = 20f;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Water")
        {
            isSwimming = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.tag == "Water")
        {
            isSwimming = false;
            movement.runSpeed = 40f;
        }
    }    
}

    


