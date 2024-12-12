using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.U2D;
using Unity.VisualScripting;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Options")]
    public float stopDelay = 1.0f; //How long the enemy will stop at each waypoint. Set to 0 for constant movement.
    public GameObject waypointObject; //What object are used for waypoints?

    public bool reverse; //Reverse sprite flipping while moving. Temporary untill movement animations get setup
    public float speed = 3.0f; //Movement speed.

    [Header("Object Dropping")]
    public bool objectDropper;
    public GameObject dropObject;
    public bool randomDrop;
    private bool isDropped;
    private GameObject dropContainer;

    [Header("Set Path")]
    [SerializeField] private Transform[] waypoints;
    private int target;

    [Header("Random Path")]
    public bool random = false; //Is the patrol random? False = A set path.

    //Together these 4 create an area for the waypoints to spawn in.
    public float xMax; //Highest X a waypoint can spawn at.
    public float yMax; //Highest Y a waypoint can spawn at.
    public float xMin; //Lowest X a waypoint can spawn at.
    public float yMin; //Lowest Y a waypoint can spawn at.
    private Transform randTarget;

    [Header("Misc")]
    public SpriteRenderer sprite;
    private float cd = 0;
    private GameObject waypointHolder;
    public EnemyHealth health;

    private void OnDrawGizmos()
    {
        if (!random)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                Gizmos.DrawIcon(waypoints[i].position, "Square.png", true, Color.red);
            }
        }
        else
        {
        }
    }

    private void Awake()
    {
        cd = stopDelay;
        waypointHolder = GameObject.Find("Waypoints");
        if (random)
        {
            randTarget = Instantiate(waypointObject, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0), Quaternion.identity, waypointHolder.transform).transform;
        }
        else
        {
            transform.position = waypoints[0].position;
        }

        if (objectDropper) {
            dropContainer = GameObject.Find("TempObjects");
        }
    }

    private void Update()
    {
        if (random)
        {
            if (objectDropper) {
                if (transform.position != randTarget.position) {

                    transform.position = Vector2.MoveTowards(transform.position, randTarget.position, speed * Time.deltaTime);
                } else {
                    if (!isDropped) {
                        if (randomDrop) {
                            transform.GetComponent<Animator>().SetTrigger("Attack");
                            Instantiate(dropObject, (new Vector3(Random.Range(4.5f, 12.2f), Random.Range(-5.5f + 0.4f, 2 + (0.4f * transform.localScale.x)), 0)), Quaternion.identity,
                                dropContainer.transform);
                            isDropped = true;
                        } else {
                            transform.GetComponent<Animator>().SetTrigger("Attack");
                            Instantiate(dropObject, new Vector3(transform.position.x + 9.8f, transform.position.y + (0.4f * transform.localScale.x), 0), Quaternion.identity,
                                dropContainer.transform);
                            isDropped = true;
                        }
                    }
                    cd += Time.deltaTime;
                    if (cd >= stopDelay) {
                        isDropped = false;
                        Destroy(randTarget.gameObject);
                        randTarget = Instantiate(waypointObject, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0), Quaternion.identity, waypointHolder.transform).transform;
                        cd = 0;
                    }
                }
            }
        }
        else
        {
            if (transform.position != waypoints[target].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[target].position, speed * Time.deltaTime);
            }
            else
            {
                cd += Time.deltaTime;
                if (cd >= stopDelay)
                {
                    target = (target + 1) % waypoints.Length;
                    cd = 0;
                }
            }

            if (waypoints[target].position.x > transform.position.x)
            {
                if (!reverse)
                    sprite.flipX = true;
                else
                    sprite.flipX = false;
            }
            else
            {
                if (!reverse)
                    sprite.flipX = false;
                else
                    sprite.flipX = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMove = other.gameObject.GetComponent<PlayerMovement>();
            PlayerHealth playerHP = other.gameObject.GetComponent<PlayerHealth>();
            if (!playerMove.invincible) // deal damage only if i frames are inactive
            {
                playerHP.Damage(1);
                StartCoroutine(playerMove.FlashDamage()); // start flashing and i frames
            }
        }
        if (other.gameObject.CompareTag("Void")) // when touching the void, die (UNUSED SCRIPT)
        {
            health.Damage(100);
        }
    }
}
