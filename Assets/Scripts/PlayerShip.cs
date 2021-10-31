using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Transform firePoint;//球を発射する位置
    public GameObject bulletPrefab;
    public GameObject explosion;

    GameContoroller gameContoroller;

    public static float px = 0;//自機位置ｘ外部ファイル参照用
    public static float py = 0;//自機位置ｙ外部ファイル参照用

    private void Start()
    {
        gameContoroller = GameObject.Find("GameContoroller").GetComponent<GameContoroller>();
    }


    // Update is called once per frame
    void Update()
    {

        Shot();
        Move();
        px = transform.position.x * 0.7f;//自機狙い弾用
        py = transform.position.y * 0.7f;//自機狙い弾用
    }
    void Shot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }
    void Move()
    {
        //Player操作
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4;
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 4;
        float moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime * 4;

        transform.position = new Vector2(
            //エリア指定して移動する
            Mathf.Clamp(transform.position.x + moveX, -2.8f, 2.8f),
            Mathf.Clamp(transform.position.y + moveY, -1.37f, 1.52f)
            );
    }

    private void OnTriggerEnter2D(Collider2D collisition)
    {
        if (collisition.CompareTag("EnemyBullet") == true)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(collisition.gameObject);
            Destroy(gameObject);
            gameContoroller.GameOver();

        }

        
    }

}
