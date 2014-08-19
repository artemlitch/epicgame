using UnityEngine;
using System.Collections;

public class SoundGroupManager : MonoBehaviour {

	public AudioClip[] Sounds;
	public bool Music=false;
	public bool RandomPitch=false;
	public float RandomPitchMin,RandomPitchMax;
	private float startingvolume;
	private int played=0;
	
	void Awake() {
		startingvolume = audio.volume;
	}
	
	void OnEnable () {
		if(Sounds.Length==0) {
			Debug.Log("There is no sound on "+gameObject.name+" SoundGroupManager, ABORT");
			this.Recycle();
			return;
		}
		if(!audio)
			gameObject.AddComponent<AudioSource>();
		PickAudio();
		if(RandomPitch)
			audio.pitch = Random.Range(RandomPitchMin,RandomPitchMax);
		SetVolume();
		audio.Play();
		StartCoroutine(WaitForStopPlaying());
	}
	
	public void SetVolume() {
		if(Music)
			audio.volume=SoundManager.instance.MusicVolume*startingvolume;
		else
			audio.volume=SoundManager.instance.SFXVolume*startingvolume;
	}
	
	void PickAudio() {
		if(Music) {
			audio.clip = Sounds[played];
			if(played<Sounds.Length-1)
				played++;
			else
				played=0;
		} else {
			audio.clip = Sounds[Random.Range(0, Sounds.Length)];
		}
	}
	
	public void ForceStop() {
		StopAllCoroutines();
		this.Recycle();
	}
	
	void OnApplicationFocus(bool focus) {
	   if(!focus) {
			StopAllCoroutines();
	    	AudioListener.pause = true;
	   }
	   else {
			AudioListener.pause = false;
			StartCoroutine(WaitForStopPlaying());
	   }
	}
	
	IEnumerator WaitForStopPlaying()
    {
        while (audio.isPlaying)
        {
            yield return 0;
        }
        
        if(SoundManager.instance.currentMusic==this&&this.enabled)
        	OnEnable();
        else
        	this.Recycle();
    }
}
