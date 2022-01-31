using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CORNER : MonoBehaviour
{
    public GameObject Rester;
    public Rigidbody2D rb2D;
    public MOTION M;
    private void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "corners")
        {
            rb2D.transform.position = Rester.transform.position;
            rb2D.velocity = Vector2.zero;
        }
    }
    public void RePositioning()
    {
        rb2D.transform.position = Rester.transform.position;
        rb2D.velocity = Vector2.zero;
        M.AIM.SetActive(true);
    }
}
