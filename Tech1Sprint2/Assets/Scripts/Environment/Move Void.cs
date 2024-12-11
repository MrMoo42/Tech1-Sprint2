using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveVoid : MonoBehaviour
{
    public Transform mirror; // center of the map (the mirror)
    public Transform pushableObject; 
    public float xAlignment; // adjustment value
    public float speed; // speed of void movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = pushableObject.position.x - mirror.position.x - xAlignment; // find the difference between the mirror and movable object in x position (adjusted slightly)
        float inverseX = mirror.position.x - offset; // get the inverse of the offset between the mirror and movable object

        Vector2 targetPos = new Vector2(inverseX, pushableObject.position.y); // set the target position of the void object to the inverse difference between the mirror and movable object, keep y equal to movable object's y

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime); // move void object to new target position
    }
}
