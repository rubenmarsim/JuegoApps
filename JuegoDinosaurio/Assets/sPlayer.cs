using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlayer : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Fuerza de salto
    /// </summary>
    public int iJump;
    /// <summary>
    /// Valocidad de movimiento
    /// </summary>
    public int iMovSpeed;
    /// <summary>
    /// Detecta si esta en contacto con el suelo o no
    /// </summary>
    bool IsEnElPiso = false;
    /// <summary>
    /// Objeto de audio
    /// </summary>
    private AudioSource Sound;
    /// <summary>
    /// Objeto para clips de audio que contendra el audio del salto
    /// </summary>
    public AudioClip audioSalto;
    /// <summary>
    /// Objeto para clips de audio que contendra el audio de la caida
    /// </summary>
    public AudioClip audiocaida;
    /// <summary>
    /// Los segundo que se va a tardar en incrementar la velocidad
    /// </summary>
    public float segIncrement;
    /// <summary>
    /// El tiempo actual
    /// </summary>
    float TiempoActual;
    #endregion Variables

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        TiempoActual = segIncrement * 60;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        TiempoActual -= 1f;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(iMovSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetMouseButtonDown(0)&&IsEnElPiso)
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
