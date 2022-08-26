using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector2 startingPosition;
    float distanceOfLiving;

    [SerializeField]
    GameObject turret;

    private void Awake() {
        startingPosition = transform.position;
        distanceOfLiving = Random.Range(1, 4);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * 10f;
        if(Vector2.Distance(startingPosition, transform.position) > distanceOfLiving) {
            Destroy(gameObject);
            Instantiate(turret, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Turret") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
