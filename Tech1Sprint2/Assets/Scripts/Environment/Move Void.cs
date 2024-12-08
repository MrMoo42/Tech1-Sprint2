using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveVoid : MonoBehaviour
{
    public Transform mirror;
    public Transform pushableObject;
    public float xAlignment;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = pushableObject.position.x - mirror.position.x - xAlignment;
        float inverseX = mirror.position.x - offset;

        Vector2 targetPos = new Vector2(inverseX, pushableObject.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
