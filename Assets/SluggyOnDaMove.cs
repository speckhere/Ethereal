using UnityEngine;

public class SluggyOnDaMove : MonoBehaviour
{

    public float speed;
    public Vector2 target;
    private Vector2 position;

    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    void Update()
    {

        
    }
}
