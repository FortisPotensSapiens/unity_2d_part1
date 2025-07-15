using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigers : MonoBehaviour
{
    private int coins = 0;
    private string saveCoinsKey;
    private void Start()
    {
        saveCoinsKey = "Level" + SceneManager.GetActiveScene().buildIndex + "Coins";
        coins = PlayerPrefs.GetInt(saveCoinsKey, 0);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Coin")
        {
            StartCoroutine(TakeCoin(collision));
        }
        else if (collision.tag == "Chest")
        {
            SceneManager.LoadScene(2);
        }
        else if (collision.tag == "DeadZone")
        {
            StartCoroutine(TakeDeadZone(collision));
        }
        else if (collision.tag == "Door")
        {
            StartCoroutine(TakeDoor(collision));
        }
        else
        {
            Debug.Log("Trigger else! " + collision.tag);
        }

    }

    IEnumerator TakeCoin(Collider2D collision)
    {
        collision.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        Destroy(collision.gameObject);
        coins++;
        PlayerPrefs.SetInt(saveCoinsKey, coins);
        PlayerPrefs.Save();
    }

    IEnumerator TakeDeadZone(Collider2D collision)
    {
        collision.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator TakeDoor(Collider2D collision)
    {
        collision.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.8f);
        var scene = SceneManager.GetActiveScene().buildIndex;
        if (scene + 1 > 3)
            SceneManager.LoadScene(0);
        SceneManager.LoadScene(scene + 1);
    }
}
