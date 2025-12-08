using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public bool gameStarted = false;

    private BirdController birdController;
    [SerializeField]
    private GameObject bird;
    private PipeSpawner pipeSpawner;
    [SerializeField]
    private MusicManager musicMgr;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        birdController = bird.GetComponent<BirdController>();
        pipeSpawner = GetComponent<PipeSpawner>();


    }
    private void Start()
    {

        gameStarted = false;
        birdController.rb.simulated = false;
    }

    public void StartGameButtonPressed()
    {
        musicMgr.GameMusic();
        birdController.rb.linearVelocity = Vector2.zero;
        score = 0;
        pipeSpawner.timer = 0;
        birdController.rb.simulated = true;
        gameStarted = true;
        for (int i = 0; i < pipeSpawner.pipeParent.childCount; i++)
        {
            Destroy(pipeSpawner.pipeParent.GetChild(i).gameObject);
        }
        pipeSpawner.SpawnPipe();
        bird.transform.position = Vector3.zero;
    }

    public void GameOver()
    {
        SFXManager.instance.Play("woodDestroy");
        musicMgr.RadioMusic();
        gameStarted = false;
        birdController.rb.simulated = false;
    }
}
