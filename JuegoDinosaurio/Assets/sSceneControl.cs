using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class sSceneControl : MonoBehaviour
{
    public GameObject Player;
    public Camera GameCamera;
    public GameObject[] aBloquePreFab;
    public float PunteroJuego;
    public float LugarSeguroDeGeneracion = 12;
    public Text txtGame;
    public bool IsLosed;
    private AudioSource Sonido;
    public AudioClip golpe;
    public AudioSource Musica;

    // Start is called before the first frame update
    void Start()
    {
        PunteroJuego = -7;
        IsLosed = false;
        Sonido = GetComponent<AudioSource>();
        Musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            GameCamera.transform.position = new Vector3(Player.transform.position.x,
                                                    GameCamera.transform.position.y,
                                                    GameCamera.transform.position.z
                                                    );

            txtGame.text = "Puntuacion: " + Mathf.Floor(Player.transform.position.x);
        }
        else
        {
            if (!IsLosed)
            {
                IsLosed = true;
                txtGame.text += "\n Game Over! \n Pulsa r para volver a empezar";
                Sonido.PlayOneShot(golpe, 1f);
                Musica.Stop();
            }
            if (IsLosed)
            {
                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        while (Player != null && PunteroJuego < Player.transform.position.x + LugarSeguroDeGeneracion)
        {
            int iIndiceBloque = Random.Range(0, aBloquePreFab.Length - 1);
            if (PunteroJuego < 0)
            {
                iIndiceBloque = 3;
            }
            GameObject ObjetoBloque = Instantiate(aBloquePreFab[iIndiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            sBloque bloque = ObjetoBloque.GetComponent<sBloque>();
            ObjetoBloque.transform.position = new Vector2(PunteroJuego + bloque.iTamaño / 2, 0);
            PunteroJuego += bloque.iTamaño;
        }

    }
}
