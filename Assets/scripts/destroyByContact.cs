using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    public GameObject shotExplosion;
    public GameObject playerExplosion;
    private GameController gameController;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }
        if(gameControllerObject = null)
        {
            Debug.Log("hello we didn't find the object");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
        Instantiate(shotExplosion, transform.position, transform.rotation);

        if (other.tag == "player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();

        }
        gameController.AddScore();
        Debug.Log("times");

    }
}
