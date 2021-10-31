using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject explosion;
    GameContoroller gameController;

    public GameObject bulletPrefab;

    public AudioClip sound1;
    AudioSource audioSource;

    float x;
    
    // Start is called before the first frame update
   public void Start()
    {
        gameController = GameObject.Find("GameContoroller").GetComponent<GameContoroller>();

        x = Random.Range(-0.7f, 0.7f);

        InvokeRepeating("Shot", 2f, 1.5f);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(x * Time.deltaTime, 0.8f*Time.deltaTime,0);

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
        }
    }

    //‹…‚ª“–‚½‚Á‚½‚ç”š”­‚·‚é
    //“–‚½‚è”»’è‚É‚Í—¼ŽÐ‚ÉCollider
    //‚Ç‚¿‚ç‚©‚ÉRigidbody‚ª‚Â‚¢‚Ä‚¢‚é

    private void OnTriggerEnter2D(Collider2D collisition)
    {
        if (collisition.CompareTag("Player") == true)
        {
            Instantiate(explosion, collisition.transform.position, transform.rotation);
            gameController.GameOver();




        }
        else if (collisition.CompareTag("Bullet") == true)
        {
            gameController.AddScore();


        }
        else if (collisition.CompareTag("EnemyBullet") == true)
        {
            return;
        }
            Instantiate(explosion,transform.position,transform.rotation);
        
        Destroy(collisition.gameObject);
        Destroy(gameObject);
    }

    void Shot()
    {
        Instantiate(bulletPrefab,transform.position,transform.rotation);
    
    }
}
