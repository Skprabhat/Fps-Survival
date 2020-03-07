using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPauseMenu;
    // Update is called once per frame
    private void Awake()
    {
        pauseMenu.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPauseMenu = !isPauseMenu;
            Time.timeScale = 0;
        }
        if (isPauseMenu)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(true);
        }
        if (!isPauseMenu)
        {
            pauseMenu.SetActive(false);
        }
    }
}
