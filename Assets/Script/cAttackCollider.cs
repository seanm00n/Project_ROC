using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cAttackCollider : MonoBehaviour
{
    public Player player;

    private void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.tag == "Monster") {
            collision.gameObject.GetComponent<Monster>().monsterHP -= player.charAP;
        }
    }
}
