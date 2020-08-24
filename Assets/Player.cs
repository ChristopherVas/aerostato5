using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int colorChangeRate = 1;
    public float speed = 15;
    public float mapWidth = 5;
    public int ChosenColor;
    private Rigidbody2D rb;
    public int score = 0;
    public int colorChange;
    public List<int> colorsID = new List<int>();
    public List<int> savedID = new List<int>();
    public List<Sprite> Images = new List<Sprite>();
    public List<Sprite> SavedSprites = new List<Sprite>();
    public GameObject explosion;
    public Image targetImage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int x = Random.Range(0, colorsID.Count);
        ChosenColor = colorsID[x];
        colorChange = 0;
        targetImage.sprite = Images[x];
        Images.RemoveAt(x);
    }

    void FixedUpdate ()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.transform.tag == "Obstacle")
        {
            
            if (collision.transform.GetComponent<ColorCode>().colorID == ChosenColor)
            {
                // dwse vathmous
                score++;
                colorChange++;
                Destroy(collision.gameObject);
                // feedback
                //ContactPoint2D point;
                // point = collision.contacts[0];
                //instatiate(prefab,point)
                Instantiate(explosion, collision.transform.position,Quaternion.identity);
                //explosion
                //FindObjectOfType<AudioManager>().Play("crash");



                //level change
                if (score>=15)
                {
                    // star end level
                }




            }
            else
            {

                ContactPoint2D point;
                point = collision.contacts[0];
                //instatiate(otheprefab,point)

            }





            if (colorChange >= colorChangeRate)
            {
                //allaxe xrwma
                colorsID.Remove(ChosenColor);

                // player feedback
                //play sound

                if (colorsID.Count<=0)
                {                   
                    for(int i = 0; i < savedID.Count; i++)
                    {
                        colorsID.Add(savedID[i]);
                    }

                    for (int i = 0; i < SavedSprites.Count; i++)
                    {
                        Images.Add(SavedSprites[i]);
                    }
                }

                if(colorsID.Count!=0) {
                    int x = Random.Range(0, colorsID.Count);
                    ChosenColor = colorsID[x];
                   
                    targetImage.sprite = Images[x];
                    Images.RemoveAt(x);
                }
                colorChange = 0;
            }
        }
    }

  

}
