using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //이 것들은 1ㄷ1 관계
    //..프리팹들을 보관할 변수
    public GameObject[] prefabs;
    //..풀 담당 하는 리스트
    List<GameObject>[] pools;

    void Awake(){
        pools = new List<GameObject>[prefabs.Length];
        
        for(int i = 0; i < pools.Length; i++){
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index){
        GameObject select = null;
        // ... 선택한 풀의 놀고 있는 (비활성화 된)게임오브젝트 접근
        //... 발견하면 select 변수에 할당 
        foreach (GameObject item in pools[index]){
            if(!item.activeSelf){
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //...못 찾았으면
        //새롭게 생성하고 select 변수에 할당 
        if(select==null){
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select);
        }
        return select;
    }


}
