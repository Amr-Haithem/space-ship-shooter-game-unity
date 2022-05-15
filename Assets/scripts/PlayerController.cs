using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    private float tilt =4;
    //instantiating the objects
    public GameObject shot;
    public Transform shotSpawner;
    private float fireRate=.25f;
    private float nextFire=0.0f;
    private int score;
    public Text scoreText;
    private void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //can make a refernce of this game object to use it there after but we don't need that for now!!
            Instantiate(shot, shotSpawner.position, shotSpawner.rotation);//as Gameobject
            GetComponent<AudioSource>().Play();

        }

    }

    private void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizonal, 0.0f, moveVertical);
        rb.velocity =movement*speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            ) ;
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -1 * tilt);
    }

    void scoreAdder(int newScoreValue)
    {
        score += newScoreValue;
        scoreUpdate();
    }
    void scoreUpdate()
    {
        scoreText.text = "score: " + score;
    }
}
