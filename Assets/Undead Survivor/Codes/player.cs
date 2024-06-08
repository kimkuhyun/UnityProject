using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class player : MonoBehaviour
{  
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    Animator anime;
    SpriteRenderer spriter;
    void Awake(){
         rigid = GetComponent<Rigidbody2D>();
         spriter = GetComponent<SpriteRenderer>();
         anime = GetComponent<Animator>();
     }

    void OnMove(InputValue value){
        inputVec = value.Get<Vector2>();
     }

    void FixedUpdate(){
         Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
       
         rigid.MovePosition(rigid.position+ nextVec);
     }
    void LateUpdate(){

        anime.SetFloat("Speed",inputVec.magnitude);
        if(inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }
        
    }


}
