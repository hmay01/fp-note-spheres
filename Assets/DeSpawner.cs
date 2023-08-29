using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> balls;

    List<List<GameObject>> chords;

    List<GameObject> singleNotes;

    public List<GameObject> floorBalls;


    Spawner spawnerScript;
    MessageUI messageUIScript;


    LayerMask groundLayer;

    BoxCollider groundCollider;

    Coroutine check;








    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");

        groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider>();

        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        messageUIScript = GameObject.FindGameObjectWithTag("MessageUI").GetComponent<MessageUI>();


        floorBalls = new List<GameObject>();


        
    }

    // Update is called once per frame
    void Update()
    {
        balls = spawnerScript.balls;
        singleNotes = spawnerScript.singleNotes;
        chords = spawnerScript.chords;




        foreach (var ball in balls)
        {

            if (isGrounded(ball) && !floorBalls.Contains(ball)) {
                check = StartCoroutine(CheckStillGrounded(ball));
            }
            
        }


        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift) && chords.Count > 0) {
            DeSpawnChord(chords[0]);
            messageUIScript.TriggerMessageUpdate("First Chord Despawned");

        }
        
        else if (Input.GetKeyDown(KeyCode.Z) && singleNotes.Count > 0){
            DeSpawnNote(singleNotes[0]); 
            messageUIScript.TriggerMessageUpdate("First Note Despawned");

        }

        else if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.LeftShift) && chords.Count > 0){
            DeSpawnChord(chords[chords.Count - 1]);
            messageUIScript.TriggerMessageUpdate("Last Chord Despawned");

        }

        else if (Input.GetKeyDown(KeyCode.X) && singleNotes.Count > 0) {
            DeSpawnNote(singleNotes[singleNotes.Count -1]); 
            messageUIScript.TriggerMessageUpdate("Last Note Despawned");

        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            DeSpawnAllBalls();
            messageUIScript.TriggerMessageUpdate("All Balls Despawned");

        }

        else if (Input.GetKeyDown(KeyCode.F) && floorBalls.Count > 0)
        {
            DeSpawnFloorBalls();
            messageUIScript.TriggerMessageUpdate("Floor Balls Despawned");

        }

    }

    void DeSpawnChord(List<GameObject> chord){
        foreach (var ball in chord)
        {
            balls.RemoveAt(balls.IndexOf(ball));
            if (floorBalls.Contains(ball)){
                floorBalls.RemoveAt(floorBalls.IndexOf(ball));
            }
            Destroy(ball);
            Destroy(ball.GetComponent<Spotlight>().spotLight);
        }
        chords.RemoveAt(chords.IndexOf(chord));

    }
        



    

    void DeSpawnNote(GameObject note){

        balls.RemoveAt(balls.IndexOf(note));

        if (floorBalls.Contains(note)){
            floorBalls.RemoveAt(floorBalls.IndexOf(note));
        }
        Destroy(note);
        Destroy(note.GetComponent<Spotlight>().spotLight);


        singleNotes.RemoveAt(singleNotes.IndexOf(note));   
        

    }

    void DeSpawnAllBalls(){

        foreach (var ball in balls)
        {
            Destroy(ball);

        }

        balls.Clear();
        chords.Clear();
        singleNotes.Clear();
        floorBalls.Clear();

    }

    void DeSpawnFloorBalls(){

        foreach (var floorBall in floorBalls)
        {
            int indexInBallsList = balls.IndexOf(floorBall);
            floorBall.GetComponent<SphereCollider>().enabled = false;
            Destroy(floorBall, 5);
            Destroy(floorBall.GetComponent<Spotlight>().spotLight);

            balls.RemoveAt(indexInBallsList);

            if (singleNotes.Contains(floorBall)) {
                int indexInSingleNotesList = singleNotes.IndexOf(floorBall);
                singleNotes.RemoveAt(indexInSingleNotesList);
            }
            else if (inNested(chords, floorBall)) {
                int chordIndex = nestedIndexes(chords, floorBall)[0];
                int ballIndex = nestedIndexes(chords, floorBall)[1];
                chords[chordIndex].RemoveAt(ballIndex);
                print("Keeping chord as it still has " + chords[chordIndex].Count + " balls");

                if (chords[chordIndex].Count <= 1) {
                    print("Removing chord because it doesn't have more than 1 ball");
                    chords.RemoveAt(chordIndex);
                }
            } 
        }

        floorBalls.Clear();
        StopAllCoroutines();

    }

    bool inNested(List<List<GameObject>> lst, GameObject ball) {
        foreach (var subList in lst)
        {
            if (subList.Contains(ball)) {
                return true;
            }
        }
        return false;
    }
    List<int> nestedIndexes(List<List<GameObject>> lst, GameObject ball) {
        foreach (var subList in lst)
        {
            if (subList.Contains(ball)) {
                List<int> indexes = new List<int>();
                int subListIndex = lst.IndexOf(subList);
                indexes.Add(subListIndex);
                int ballIndex = subList.IndexOf(ball);
                indexes.Add(ballIndex);
                return indexes;
            }
        }
        return null;
    }

    IEnumerator CheckStillGrounded(GameObject ball) {
        float limit = 3;
        float elapsed = 0;

        while(elapsed < limit)
        {

            // print(ball);
            if(ball == null){
                yield break;
            }
            else if (!isGrounded(ball))
            {
                yield break;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        if (!floorBalls.Contains(ball)) {
            floorBalls.Add(ball);
        }

        yield return null;

    }



    private bool isGrounded(GameObject ball){
        float ballHeight = ball.GetComponent<SphereCollider>().bounds.size.y;
        bool hit = Physics.Raycast(ball.transform.position, Vector3.down, ballHeight * 0.5f + 0.2f, groundLayer);
        return hit;

    }







}
