using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.Storage;
public class AudioManager : BaseManager<AudioManager>
{
    private float bgmFadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_HIGHT;

    private string nextBGMName;
    private string nextSEName;
    public AudioSource AttachBGMSource;
    public AudioSource AttachSESource;
    private bool isFadeOut = false;


    private Dictionary<string, AudioClip> bgmDic, seDic;

    protected override void Awake()
    {
        base.Awake();
        //Load all SE & BGM files from resource folder
        bgmDic = new Dictionary<string, AudioClip>();
        seDic = new Dictionary<string, AudioClip>();

        object[] bgmList = Resources.LoadAll("Audio/BGM");      //tìm kiếm trong asset cái folder BGM load hết và mảng
        object[] seList = Resources.LoadAll("Audio/SE");

        foreach (AudioClip bgm in bgmList)
        {
            bgmDic[bgm.name] = bgm;
        }
        foreach (AudioClip se in seList)
        {
            seDic[se.name] = se;
        }
    }
    private void Start()
    {
        AttachBGMSource.volume = ObscuredPrefs.GetFloat(CONST.BGM_VOLUME_KEY, CONST.BGM_VOLUME_DEFAULT);
        AttachSESource.volume = ObscuredPrefs.GetFloat(CONST.SE_VOLUME_KEY,CONST.SE_VOLUME_DEFAULT);
        AttachBGMSource.mute = ObscuredPrefs.GetBool(CONST.BGM_MUTE_KEY, CONST.BGM_MUTE_DEFAULT);
        AttachSESource.mute = ObscuredPrefs.GetBool(CONST.SE_MUTE_KEY,CONST.SE_MUTE_DEFAULT);
    }
    public void PlaySE(string seName, float delay = 0.0f)
    {
        if (!seDic.ContainsKey(seName))
        {
            Debug.Log(seName + "There is no SE named");
            return;
        }

        nextSEName = seName;
        Invoke("DelayPlaySE", delay);
    }
    private void DelayPlaySE()
    {
        AttachSESource.PlayOneShot(seDic[nextSEName] as AudioClip);
    }

    public void PlayBGM(string bgmName, float fadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_HIGHT)
    {
        if (!bgmDic.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "There is no BGM named");
            return;
        }

        //If BGM is not currently playing, play it as is
        if (!AttachBGMSource.isPlaying)
        {
            nextBGMName = "";
            AttachBGMSource.clip = bgmDic[bgmName] as AudioClip;
            AttachBGMSource.Play();
        }
        //When a different BGM is playing, fade out the BGM that is playing before playing the next one.
        //Through when the same BGM is playing
        else if (AttachBGMSource.clip.name != bgmName)
        {
            nextBGMName = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }

    }
    public void FadeOutBGM(float fadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_LOW)
    {
        bgmFadeSpeedRate = fadeSpeedRate;
        isFadeOut = true;
    }
    private void Update()
    {

        if (!isFadeOut)
        {
            return;
        }
        Debug.Log("hehehe");
        //Gradually lower the volume, and when the volume reaches 0
        //return the volume and play the next song
        AttachBGMSource.volume -= Time.deltaTime * bgmFadeSpeedRate;
        if (AttachBGMSource.volume <= 0)
        {
            Debug.Log("never");
            AttachBGMSource.Stop();
            AttachBGMSource.volume = ObscuredPrefs.GetFloat(CONST.BGM_VOLUME_KEY, CONST.BGM_VOLUME_DEFAULT);
            isFadeOut = false;

            if (!string.IsNullOrEmpty(nextBGMName))
            {
                PlayBGM(nextBGMName);
            }
        }
    }
    public void ChangeBGMVolume(float BGMVolume)
    {
        AttachBGMSource.volume = BGMVolume;
        ObscuredPrefs.SetFloat(CONST.BGM_VOLUME_KEY, BGMVolume);
    }

    public void ChangeSEVolume(float SEVolume)
    {
        AttachSESource.volume = SEVolume;
        ObscuredPrefs.SetFloat(CONST.SE_VOLUME_KEY, SEVolume);
    }
    public void MuteBGM(bool isMute)
    {
        AttachBGMSource.mute = isMute;
        ObscuredPrefs.SetBool(CONST.BGM_MUTE_KEY, isMute);
    }
    public void MuteSE(bool isMute)
    {
        AttachSESource.mute = isMute;
        ObscuredPrefs.SetBool(CONST.SE_MUTE_KEY, isMute);
    }
}

