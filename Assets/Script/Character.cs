using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector2 loc;//캐릭터 좌표
    public int hp;
    public int mp;
    public int ap;
    public int exp;

    public Character(){
        this.hp = 100;
        this.mp = 100;
        this.ap = 10;
        this.exp = 0;
    }
    public void fixTurret()
    {

    }
    
    void Update()
    {
        
    }
}
