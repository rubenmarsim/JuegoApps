using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSceneControl : MonoBehaviour
{
    public GameObject Player;
    public Camera GameCamera;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
