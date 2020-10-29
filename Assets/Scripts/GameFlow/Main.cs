using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main _Instance;
    public static Main GetSingleton() { return _Instance; }
    private void Awake()
    {
        _Instance = this;
    }

    public UIController UIMgr;
    public Player Player1;
    public Player Player2;
    public AudioSource SoundAS;


    private EGameState GameState;
    private Dictionary<string, AudioClip> mAudioDic;

    // Start is called before the first frame update
    void Start()
    {
        this.InitAudio();
        this.Player1 = new Player1();
        this.Player2 = new Player2();
        this.SetState(EGameState.SPLASH);
    }

    // Update is called once per frame
    void Update()
    {
        this.Player1.Update();
        this.Player2.Update();
        this.UpdateState();
    }

    public void SetState(EGameState aState)
    {
        this.GameState = aState;
    }

    private void UpdateState()
    {
        switch (this.GameState)
        {
            case EGameState.SPLASH:
                {
                    this.Player1.Phase = EPlayerPhase.FREE;
                    this.Player2.Phase = EPlayerPhase.FREE;

                    this.UIMgr.HideAllNodes();
                    this.UIMgr.SplashNode.SetActive(true);
                    this.SetState(EGameState.WAIT);
                }
                break;
            case EGameState.SELECT:
                {
                    this.Player1.Phase = EPlayerPhase.SELECT;
                    this.Player2.Phase = EPlayerPhase.SELECT;
                    this.Player1.CharacterID = 1;
                    this.Player2.CharacterID = 2;

                    this.UIMgr.HideAllNodes();
                    this.UIMgr.SelectNode.SetActive(true);
                    this.SetState(EGameState.WAIT);
                }
                break;
            case EGameState.BATTLE:
                {
                    this.Player1.InitBattle();
                    this.Player2.InitBattle();


                    this.UIMgr.HideAllNodes();
                    this.UIMgr.BattleNode.SetActive(true);
                    UIBattle ui = this.UIMgr.BattleNode.GetComponent<UIBattle>();
                    ui.Init();
                    this.SetState(EGameState.WAIT);
                }
                break;
            default:
                break;
        }
    }

    public void InitAudio()
    {
        this.mAudioDic = new Dictionary<string, AudioClip>();
        var audios = Resources.LoadAll<AudioClip>("Audio");
        foreach (var audio in audios)
        {
            this.mAudioDic.Add(audio.name, audio);
        }
    }

    public void PlaySound(string a_strAudio)
    {
        AudioClip audio = null;
        this.mAudioDic.TryGetValue(a_strAudio, out audio);
        if (audio == null)
        {
            return;
        }
        this.SoundAS.loop = false;
        this.SoundAS.PlayOneShot(audio);
    }

    public void StopSound()
    {
        this.SoundAS.Stop();
    }

    public void SetSoundVolume(float a_Volume)
    {
        this.SoundAS.volume = a_Volume;
    }
}
