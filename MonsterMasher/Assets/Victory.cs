using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().speed = 1.2f;
        gameObject.GetComponent<EnemyHitable>().Died += Win;
    }

    private void Win() {
        StartCoroutine("LoadEnding");
    }


    IEnumerator LoadEnding()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
