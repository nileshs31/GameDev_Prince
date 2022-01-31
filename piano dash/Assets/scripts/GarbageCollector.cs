using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin" || collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
