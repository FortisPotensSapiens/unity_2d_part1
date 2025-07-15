using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigers : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Coin")
        {
            StartCoroutine(TakeCoin(collision));
        }
        else if (collision.tag == "Chest")
        {
            SceneManager.LoadScene(1);
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
        SceneManager.LoadScene(2);
    }
}
