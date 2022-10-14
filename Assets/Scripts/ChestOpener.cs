using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    private Animator animator;
    public GateInteract gate;
    private bool playerNear;
    private bool interacted;
    public bool isKey;
    public bool haveKey; 

   void Start()
   {
       animator = this.gameObject.GetComponent<Animator>();
       interacted = false;
       haveKey = false;
       isKey = true;
   }
   void Update()
    {
        if(!interacted && playerNear)
        {
            if(Input.GetKey("e") && playerNear)
            {
                //this is were we pick what were giving the player
                if(isKey && playerNear){
                    //KEY  
                    animator.SetTrigger("interacted"); //change this interacted_with_key? 
                    interacted = true;
                    haveKey = true; 
                    Debug.Log("HOLY SHIT GOLD!!, And a KEY");
                }
                else {
                    //EMPTY CHEST
                    animator.SetTrigger("interacted");
                    interacted = true;
                    Debug.Log("HOLY SHIT GOLD!!, NO KEY");
                }
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
