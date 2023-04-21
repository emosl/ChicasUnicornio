// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class moves : MonoBehaviour
// {
//     [SerializeField] float speed;
//     [SerializeField] float limitx;
//     [SerializeField] float limity;
//     Vector3 move;

//     private SpriteRenderer spriteRenderer;
//     public Sprite idleSprite;
//     public Sprite leapSprite;

//     private void Awake()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//          move.x=Input.GetAxis("Horizontal");
//          move.y=Input.GetAxis("Vertical");
         
//         //Debug.Log("X motion: "+ move.x);

//          if(transform.position.x < -limitx && move.x < 0){
//              move.x=0;
//          }
//         else if(transform.position.x > limitx && move.x > 0){
//             move.x=0;
//          }
//          if(transform.position.y < -limity && move.y < 0){
//              move.y=0;
//          }
//         else if(transform.position.y > limity && move.y > 0){
//              move.y=0;
//          }
//         //Esta función permite deterimanr la velocidad para que lado en el tiempo transcurrido.
//         transform.Translate(move * speed * Time.deltaTime);
//     }

        
//     }

