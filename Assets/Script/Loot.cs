using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Vector3 startingPosition;
    float direction;
    [SerializeField] float maxMovementDistance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.y <= startingPosition.y)
        {
            direction = 0.2f;
        }else if (currentPosition.y >= startingPosition.y + maxMovementDistance)
        {
            direction = -0.2f;
        }
        myRigidbody.velocity = new Vector2(0, direction);

    }
}
