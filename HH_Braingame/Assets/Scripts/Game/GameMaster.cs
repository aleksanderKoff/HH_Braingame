using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private PlayerMovement move;
    private DisplayChallenge display;
    private ControllerCamera camControl;
    private drop_projectile dropProjectile;

    GameObject boss;

    private Button button1;
    private Button button2;
    private Button button3;

    public PlayerMovement Move { get => move; set => move = value; }
    public DisplayChallenge Display { get => display; set => display = value; }
    public ControllerCamera CamControl { get => camControl; set => camControl = value; }
    public drop_projectile DropProjectile { get => dropProjectile; set => dropProjectile = value; }
    public Button Button1 { get => button1; set => button1 = value; }
    public Button Button2 { get => button2; set => button2 = value; }
    public Button Button3 { get => button3; set => button3 = value; }
    
    
    void Awake()
    {
        InitComponents();
        
    }

    void InitComponents()
    {
        // Nullcheck for object references
        
        Move = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerMovement>();
        Display = GameObject.FindGameObjectWithTag("Player")?.GetComponent<DisplayChallenge>();
        CamControl = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<ControllerCamera>();
        DropProjectile = GameObject.Find("ProjectileSpawner")?.GetComponent<drop_projectile>();

        boss = GameObject.Find("HeadMaster");

        Button1 = GameObject.Find("Button")?.GetComponent<Button>();
        Button2 = GameObject.Find("Button (1)")?.GetComponent<Button>();
        Button3 = GameObject.Find("Button (2)")?.GetComponent<Button>();

    }
}
