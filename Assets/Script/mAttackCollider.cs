using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mAttackCollider : MonoBehaviour {
    public Monster monster;

    private void OnCollisionEnter2D (Collision2D collision) {

        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().charHP -= monster.monsterAP;
        }
        if(collision.gameObject.tag == "Turret") {
            collision.gameObject.GetComponent<Turret>().turretHP -= monster.monsterAP;
        }
        if (collision.gameObject.tag == "Barricade") {
            collision.gameObject.GetComponent<Barricade>().barricadeHP -= monster.monsterAP;
        }
        if (collision.gameObject.tag == "Nexus") {
            collision.gameObject.GetComponent<Nexus>().nexusHP -= monster.monsterAP;
        }
    }
}
