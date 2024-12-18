using UnityEngine;

public class AudioManager : MonoBehaviour {
	public AudioClip[] drumClips;
	private int maxSimultaneousSounds = 10;

	private AudioSource[] audioSources;
	private int currentIndex = 0;

	void Awake() {
		// Create a pool of AudioSources
		audioSources = new AudioSource[maxSimultaneousSounds];
		for (int i = 0; i < maxSimultaneousSounds; i++) {
			GameObject audioObject = new GameObject("AudioSource_" + i);
			audioSources[i] = audioObject.AddComponent<AudioSource>();
			audioObject.transform.SetParent(transform);
		}
	}

	public void PlayDrumSound(string drumSound) {
		int clipIndex = ConvertToIndex(drumSound);

		if (clipIndex < 0 || clipIndex >= drumClips.Length) {
			Debug.LogWarning("Clip index out of range!");
			return;
		}

		// Get the next available AudioSource
		AudioSource audioSource = audioSources[currentIndex];
		currentIndex = (currentIndex + 1) % maxSimultaneousSounds;

		// Play the sound
		audioSource.clip = drumClips[clipIndex];
		audioSource.Play();
	}

	private int ConvertToIndex(string drumSound) {
		switch (drumSound) {
			case "djembe-bass":
				return 0;
			case "djembe-snare":
				return 1;
			case "drumset-bass":
				return 2;
			case "drumset-crash":
				return 3;
			case "drumset-floortom":
				return 4;
			case "drumset-hihat":
				return 5;
			case "drumset-ride":
				return 6;
			case "drumset-snare":
				return 7;
			case "drumset-tom1":
				return 8;
			case "drumset-tom2":
				return 9;
			case "bongos-bongo2":
				return 10;
			case "bongos-bongo1":
				return 11;
			case "bongos-conga1":
				return 12;
			case "bongos-conga2":
				return 13;
			case "bongos-cymbal2":
				return 14;
			case "bongos-cymbal1":
				return 15;
			case "metronome":
				return 16;
			default:
				return -1;
		}
	}
}
