using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{

    [SerializeField] public GameObject menuUI;

    private void Awake()
    {
        menuUI.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
    }
}
