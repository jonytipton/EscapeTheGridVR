using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public GameObject tutDisc;

    public void StartDiscBattle() {
        Debug.Log("Requested: DiscBattle");
        SceneManager.LoadScene("DiscBattle");
    }

    public void StartDiscBattleTut() {
        Debug.Log("Requested: DiscTut");
        tutDisc.SetActive(true);
        tutDisc.GetComponent<Rigidbody>().useGravity = true;
       
    }

    //TODO
    public void StartRezRacer() {

    }

    //TODO
    public void StartRezRacerTut() {

    }

    //TODO
    public void StartDroneFlight() {

    }

    //TODO
    public void StartDroneFlightTut() {

    }

    public void QuitGame() {
        Application.Quit();
    }

}
