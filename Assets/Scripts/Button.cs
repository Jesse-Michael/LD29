using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseUpAsButton()
    {

        switch (name)
        {
            case "play":
                SceneManager.LoadScene("Game");
                break;

        }
    }
}
