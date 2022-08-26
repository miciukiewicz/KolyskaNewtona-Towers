using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text turretCounterText = null;
    void Update()
    {
        var turretCount = GameObject.FindGameObjectsWithTag("Turret").Length;
        turretCounterText.text = $"Towers: {turretCount}";

        if(turretCount > 100) {
            var allTurrets = GameObject.FindObjectsOfType<TowerController>();
            // change state to active and reset shoot counter
            
            //foreach(var turret in allTurrets) {
            //}
        }
    }
}
