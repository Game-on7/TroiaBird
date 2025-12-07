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
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
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
        birdController.rb.simulated = true;
        gameStarted = true;
        pipeSpawner.SpawnPipe();
        bird.transform.position = Vector3.zero;
    }

    public void GameOver()
    {
        GameManager.instance.gameStarted = false;
        birdController.rb.simulated = false;
    }

}
