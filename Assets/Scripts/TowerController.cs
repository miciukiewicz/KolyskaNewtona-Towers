using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    GameObject shootingPoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    bool isFirstTurret = false;

    int shootCounter = 0;
    float timePassed;
    float spawnDelay = 6f;
    bool spawnDelayEnded;

    TowerState TowerStatus { 
        get { return towerStatus; } 
        set {
            if(towerStatus == value) {
                return;
            } else {
                towerStatus = value;
                onTowerStateChange?.Invoke(this, null);
            }
        }   
    } 
    TowerState towerStatus;
    EventHandler onTowerStateChange;

    enum TowerState {
        waiting = 0,
        active = 1,
        inactive = 2,
        resurected = 3,
        unknown = 4
    }


    private void Awake() {
        GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        if(isFirstTurret) {
            spawnDelayEnded = true;
        } else {
            StartCoroutine(r_spawnDelay());
        }
    }
    void Update()
    {
        if(spawnDelayEnded && shootCounter < 12) {
            GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            if(timePassed > 0.5f) {
                transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(15, 45)));
                timePassed = 0;
                shootProjectile();
            }
            timePassed += Time.deltaTime;
        }else if(spawnDelayEnded && shootCounter >= 12) {
            GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    void onTowerStateChanged() {

    }

    void shootProjectile() {
        Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        shootCounter++;
    }

    IEnumerator r_spawnDelay() {
        yield return new WaitForSeconds(spawnDelay);
        spawnDelayEnded = true;
    }
}
