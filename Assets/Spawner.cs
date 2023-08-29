using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [Header("General")]
    public GameObject ballPrefab;

    public List<Material> renderMaterials;


    public List<GameObject> balls;

    public List<List<GameObject>> chords;

    public List<GameObject> singleNotes;

    MessageUI messageUIScript;

    NoteInfo noteInfoScript;

    PopulateNotes populateNotesScript;
    List<Note> notes;


    [Header("Position")]

    public float yPosition;

    public float xPositionRange;


    public float zPositionRange;
    

    [Header("Bounce")]

    public PhysicMaterial infiniteBounceMaterial;

    public PhysicMaterial highBounceMaterial;

    public PhysicMaterial lowBounceMaterial;

    public PhysicMaterial noneBounceMaterial;

    IDictionary<int, (string, PhysicMaterial)> bounceDict = new Dictionary<int, (string, PhysicMaterial)>();

    int defaultBounceSetting = 3;

    int bounceSetting;

    public string bounceMode;

    public PhysicMaterial bounceMaterial;

    TMPro.TextMeshProUGUI messageUI;



    // Start is called before the first frame update
    public void Start()
    {
        messageUIScript = GameObject.FindGameObjectWithTag("MessageUI").GetComponent<MessageUI>();
        populateNotesScript = GameObject.FindGameObjectWithTag("PopulateNotes").GetComponent<PopulateNotes>();


        notes = populateNotesScript.notes;



        bounceDict.Add(3, ("INFINITE", infiniteBounceMaterial));
        bounceDict.Add(2, ("HIGH", highBounceMaterial));
        bounceDict.Add(1, ("LOW", lowBounceMaterial));
        bounceDict.Add(0, ("NONE", noneBounceMaterial));

        bounceSetting = defaultBounceSetting;

        chords = new List<List<GameObject>>();
        singleNotes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {





        bounceMode = bounceDict[bounceSetting].Item1;
        bounceMaterial = bounceDict[bounceSetting].Item2;




        if (Input.GetKeyDown(KeyCode.Alpha1)){
            AddSingleNote();
        }

        if(Input.GetKeyDown(KeyCode.B)){
            bounceSetting = UpdateBounceSetting(bounceSetting);
            }

        if (Input.GetKeyDown(KeyCode.M)){
            ChangeMaterialSettings();
        }

        for (int i = 2; i < 10; i++)
        {
            if(Input.GetKeyDown((KeyCode)(48+i))){
                //in any normal case where 1 wasn't treated differently, you could have KeyCode(48+i) and then AddChord(i)
               AddChord(i);
            }
        } 
        
    }

    void AddSingleNote() {
        GameObject ball = SpawnBall();
        balls.Add(ball);
        singleNotes.Add(ball);


        messageUIScript.TriggerMessageUpdate("Single Note Added");

    }

    void AddChord(int numberOfBalls) {
        List<GameObject> currentChord = new List<GameObject>();

        for (int i = 0; i < numberOfBalls; i++){
            GameObject ball = SpawnBall();
            balls.Add(ball);
            currentChord.Add(ball);
            
        }
        chords.Add(currentChord);
        messageUIScript.TriggerMessageUpdate(currentChord.Count + " Ball Chord Added");


    }


    GameObject SpawnBall() {

        int randomNoteIndex = Random.Range(0, notes.Count);
        Note note = notes[randomNoteIndex];
        Material renderMaterial = GetRandomMaterial();

        float randomXPosition = Random.Range(-xPositionRange, xPositionRange);
        float randomZPosition = Random.Range(-zPositionRange, zPositionRange);

        GameObject ball = Instantiate(ballPrefab, new Vector3(randomXPosition, yPosition, randomZPosition) + transform.position, Quaternion.identity);

        noteInfoScript = ball.GetComponent<NoteInfo>();
        noteInfoScript.note = note;



        ball.transform.localScale = new Vector3(note.transformScale, note.transformScale, note.transformScale);
    
        ball.gameObject.GetComponent<Renderer>().material = renderMaterial;


        ball.gameObject.GetComponent<SphereCollider>().material = bounceMaterial;        

        int randomClipIndex = Random.Range(0, note.audioClips.Count);

        AudioSource soundSource = ball.gameObject.GetComponent<AudioSource>();

        soundSource.clip = note.audioClips[randomClipIndex];

        return ball;

    }

    int UpdateBounceSetting(int bounceSetting){
        if (bounceSetting == 0) {
            return 3;
        }
        else {
            return bounceSetting - 1;
        }
    }
    Material GetRandomMaterial(){
        int randomIndex = Random.Range(0, renderMaterials.Count);
        return renderMaterials[randomIndex];
    }

    void ChangeMaterialSettings(){

        foreach (var material in renderMaterials)
        {
            material.SetFloat("_Glossiness", 0f);
            material.SetFloat("_Metallic", 0f);
            material.SetColor("_EmissionColor", Color.black);
        }

    }
    // void ChangeMaterialSettings(){

    //     foreach (var material in renderMaterials)
    //     {
    //         material.SetFloat("_Glossiness", 1f);
    //         material.SetFloat("_Metallic",0.5f);
    //         material.SetColor("_EmissionColor", Color.white);
    //     }

    // }


}
