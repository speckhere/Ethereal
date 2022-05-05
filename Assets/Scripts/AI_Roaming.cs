using UnityEngine;

public class AI_Roaming : MonoBehaviour
{

    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range (0, moveSpots.Length);
    }

    void Update() 
    {
         transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
   
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) 
        {
            if(waitTime <= 0) 
            {
                randomSpot = Random.Range (0, moveSpots.Length);
                waitTime = startWaitTime;
            } else
                {
                    waitTime -= Time.deltaTime;
                }
        }

    }



}
