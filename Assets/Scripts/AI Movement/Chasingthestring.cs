using UnityEngine;

public class Chasingthestring : MonoBehaviour
{
    //private bool facingRight;
    //private bool facingLeft;
    public Animator animator;

    private Vector2 pos;
    public float startPos;

    public GameObject originPositionsObject;

void Start()
    {
        //facingLeft = true;
        animator = GetComponent<Animator>();

        startPos = pos.x;
    }

void Update()
    {
        float currentPos = transform.position.x;

        if(currentPos > startPos)
        {
            // right
            //facingRight = true;
            animator.Play("SlugRight");
        }
        else if(currentPos < startPos)
        {
            // left
            //facingLeft = true;
            animator.Play("SlugLeft");
        }
        startPos = currentPos;
    }
}
