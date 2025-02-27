using UnityEngine;

public class Home3Door : MonoBehaviour
{
    [SerializeField] private Vector3 secondPosition = new Vector3(0, 1, 0);
    [SerializeField] private Vector3 firstPosition = new Vector3(0, 1, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == firstPosition  ){
            transform.position = secondPosition;
        }
        else if(transform.position == secondPosition ){
            transform.position = firstPosition;
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if(transform.position == firstPosition  ){
                transform.position = secondPosition;
            }
            else if(transform.position == secondPosition ){
                transform.position = firstPosition;
            }
        }
    }
}
