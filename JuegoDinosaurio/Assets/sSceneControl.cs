using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSceneControl : MonoBehaviour
{
    public GameObject Player;
    public Camera GameCamera;
    public GameObject[] aBloquePreFab;
    public double PunteroJuego;
    public double LugarSeguroDeGeneracion = 12;

    // Start is called before the first frame update
    void Start()
    {
        PunteroJuego = -7;
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
        }

        while (Player != null && PunteroJuego < Player.transform.position.x + LugarSeguroDeGeneracion)
        {
            int iIndiceBloque = Random.Range(0, aBloquePreFab.Length - 1);
        }

    }
}
