using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    [Header("Gifts")]
    public int gift = 0;
    public Text giftUI;

    void Start() {
        //giftUI = GetComponent<Text>();  
    }

    private void Awake() {

        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Respawn() {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }

    public void IncreaseGift(int amount) {
        gift += amount;
        giftUI.text = gift + " gifts";
    }
}
