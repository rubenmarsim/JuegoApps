using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlayer : MonoBehaviour
{
    public int iJump;
    public int iMovSpeed;
    bool IsEnElPiso = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(iMovSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown("space")&&IsEnElPiso)
        {
            IsEnElPiso = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, iJump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsEnElPiso = true;
        if (collision.gameObject.tag.Equals("Obstaculo"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnElPiso = true;
        if (collision.tag.Equals("Obstaculo"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    IsEnElPiso = false;
    //}

}
