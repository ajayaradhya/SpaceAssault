using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] GameObject explosionFX;

	void OnTriggerEnter(Collider other)
    {
        explosionFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("ReloadLevel", 1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
