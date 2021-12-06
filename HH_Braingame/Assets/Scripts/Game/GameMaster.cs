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
    private Clicker clicker;
    private HydrationManager hydrationManager;
    private PlayerMovement playerMovement;
    private Player player;
    private Respawn respawn;
    private ReactionProblem reactionProblem;

    private BossGrid bossGrid;
    private BossClicker bossClicker;
    private BossHealth bossHealth;

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
    public BossClicker BossClicker { get => bossClicker; set => bossClicker = value; }
    public Clicker Clicker { get => clicker; set => clicker = value; }
    public HydrationManager HydrationManager { get => hydrationManager; set => hydrationManager = value; }
    public BossGrid BossGrid { get => bossGrid; set => bossGrid = value; }
    public BossHealth BossHealth { get => bossHealth; set => bossHealth = value; }
    public PlayerMovement PlayerMovement { get => playerMovement; set => playerMovement = value; }
    public Player Player { get => player; set => player = value; }
    public Respawn Respawn { get => respawn; set => respawn = value; }
    public ReactionProblem ReactionProblem { get => reactionProblem; set => reactionProblem = value; }

    void Awake()
    {
        InitComponents();
    }

    void InitComponents()
    {
        // Nullcheck for object references
        
        Move = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerMovement>();
        Display = GameObject.FindGameObjectWithTag("Player")?.GetComponent<DisplayChallenge>();
        PlayerMovement = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerMovement>();
        Player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        Respawn = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Respawn>();
        ReactionProblem = GameObject.FindGameObjectWithTag("Player")?.GetComponent<ReactionProblem>();
        CamControl = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<ControllerCamera>();
        Clicker = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Clicker>();
        DropProjectile = GameObject.Find("ProjectileSpawner")?.GetComponent<drop_projectile>();
        HydrationManager = GameObject.Find("Hydration")?.GetComponent<HydrationManager>();

        BossGrid = GameObject.Find("BossGrid")?.GetComponent<BossGrid>();
        BossClicker = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<BossClicker>();
        BossHealth = GameObject.Find("DestroyProjectile")?.GetComponent<BossHealth>();

        Button1 = GameObject.Find("Button")?.GetComponent<Button>();
        Button2 = GameObject.Find("Button (1)")?.GetComponent<Button>();
        Button3 = GameObject.Find("Button (2)")?.GetComponent<Button>();

    }
}
