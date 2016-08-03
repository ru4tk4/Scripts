using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour {
    private Player player;
    private Input_Handler IH;
    public float SaveTime;
    public bool RegularSaveSwitch;
   
    public Data[] data = new Data[3]; 
    [System.Serializable]
    public class Data
    {
        public float[] D = new float[10];
        

    }



    void Awake()
    {
        player = gameObject.GetComponent<Player>();
        IH = gameObject.GetComponent<Input_Handler>();
        
        //SaveGame();
        //PlayerPrefs.SetInt("Open", 0);
        //LoadGame();
        if (PlayerPrefs.GetInt("Open") == 0)
        {
            SaveGame();
            PlayerPrefs.SetInt("Open", 1);
        }
        if (PlayerPrefs.GetInt("GO") == 1)
        {
            SceneChange(null);
        }

    }
        // Use this for initialization
    void Start () {
        
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            string J = SceneManager.GetActiveScene().name;
            die(J);
        }*/
    }

    IEnumerator RegularSave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        if (RegularSaveSwitch == true)
        {
            
        }
        else {
            StartCoroutine(RegularSave(SaveTime));
        }
    }

    public void die(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        PlayerPrefs.SetInt("GO", 1);
    }

    public void SceneChange(string SceneName )
    {
        if(SceneName != null)
        {
            
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
            PlayerPrefs.SetInt("GO", 1);
            SaveGame();
        }
        else
        {
            //輸入null為讀取
            LoadGame();
            

            PlayerPrefs.SetInt("GO", 0);
        }
       
    }

    public void SaveGame()
    {
        string S = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SaveNow",S);
        PlayerPrefs.SetFloat("Energy", player.energy);
        PlayerPrefs.SetFloat("HP", player.hp);
        PlayerPrefsX.GetVector3("PlayerPOS", gameObject.transform.position);
        PlayerPrefsX.SetBoolArray("UI1", NewerUI.Ala);
        PlayerPrefsX.SetBoolArray("UI2", NewerUI.Alce);
        int t = 0;
        foreach(Player.WeaponData wd in player.WD)
        {
            
            data[t].D[0] = wd.Gunlost;
            data[t].D[1] = wd.bulletdem;
            data[t].D[2] = wd.bulletRato;
            data[t].D[3] = wd.ShootRange;
            data[t].D[4] = wd.BulletSpeed;
            data[t].D[5] = wd.fire_CD;
            data[t].D[6] = wd.Magazine;
            data[t].D[7] = wd.reloadTime;
            data[t].D[8] = wd.AtkRise;
            data[t].D[9] = wd.AtkRatio;
            PlayerPrefsX.SetFloatArray("T"+t, data[t].D);
            t++;

        }
        //PlayerPrefsX.SetFloatArray("A", data[0].D);
        //PlayerPrefsX.SetFloatArray("B", data[1].D);

    }

    public void LoadGame()
    {
        player.energy = PlayerPrefs.GetFloat("Energy");
        player.hp = PlayerPrefs.GetFloat("HP");
        NewerUI.Ala = PlayerPrefsX.GetBoolArray("UI1");
        NewerUI.Alce =PlayerPrefsX.GetBoolArray("UI2");
        int t = 0;
       // data[0].D = PlayerPrefsX.GetFloatArray("A");
       // data[1].D = PlayerPrefsX.GetFloatArray("B");
        foreach (Player.WeaponData wd in player.WD)
        {
            data[t].D = PlayerPrefsX.GetFloatArray("T"+t);
            wd.Gunlost= data[t].D[0];
            wd.bulletdem=data[t].D[1];
            wd.bulletRato= data[t].D[2];
            wd.ShootRange= data[t].D[3] ;
            wd.BulletSpeed = data[t].D[4];
            wd.fire_CD = data[t].D[5];
            wd.Magazine = data[t].D[6] ;
            wd.reloadTime = data[t].D[7] ;
            wd.AtkRise = data[t].D[8] ;
            wd.AtkRatio = data[t].D[9] ;

            t++;

        }
    }

    public void SavePosition(Transform Obj)
    {
        print(PositionArray(Obj.position)[1]);
    }

    public float[] PositionArray(Vector3 Pos)
    {
        float[] Ret=new float[3];
        
        Ret[0] = Pos.x;
        Ret[1] = Pos.y;
        Ret[2] = Pos.z;

        return Ret;
    }

    

}
