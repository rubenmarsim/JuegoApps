using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlayer : MonoBehaviour
{
    public int iJump;
    public int iMovSpeed;
    bool IsEnElPiso = false;
    private AudioSource Sound;
    public AudioClip audioSalto;
    public AudioClip audiocaida;
    public float segIncrement;
    float TiempoActual;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        TiempoActual = segIncrement * 60;
    }

    // Update is called once per frame
    void Update()
    {
        TiempoActual -= 1f;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(iMovSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown("space")&&IsEnElPiso)
        {
            Sound.PlayOneShot(audioSalto, 1f);
            IsEnElPiso = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, iJump));
        }
        if (TiempoActual < 0)
        {
            iMovSpeed += 1;
            TiempoActual = segIncrement * 60;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsEnElPiso = true;
        Sound.PlayOneShot(audiocaida, 1f);
        if (collision.gameObject.tag.Equals("Obstaculo"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnElPiso = true;
        Sound.PlayOneShot(audiocaida, 1f);
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
