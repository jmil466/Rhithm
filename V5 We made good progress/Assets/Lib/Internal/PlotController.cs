using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlotController : MonoBehaviour {

	public List<Transform> plotPoints;
	private Material highlightMaterial;
	public int displayWindowSize = 300;
	public float BPM;
	public float secondsPerBeat;

	public GameObject noteOne;
	public GameObject noteTwo;
	public GameObject noteThree;

	public float elapsedTime = 0;
	float previousTime;
	int counter;

	float nothingFlux = 0.025f;
	float obstacleFlux = 0.05f;
	float noteOneFlux = 0.1f;
	float noteTwoFlux = 0.15f;

	// Use this for initialization
	void Start () {

		secondsPerBeat = 60 / BPM;
		plotPoints = new List<Transform> ();

		

		float localWidth = transform.Find("Point/BasePoint").localScale.x;
		// -n/2...0...n/2
		for (int i = 0; i < displayWindowSize; i++) {
			//Instantiate point
			Transform t = (Instantiate(Resources.Load("Point"), transform) as GameObject).transform;

			// Set position
			float pointX = (displayWindowSize / 2) * -1 * localWidth + i * localWidth;
			t.localPosition = new Vector3(pointX, t.localPosition.y, t.localPosition.z);

			plotPoints.Add (t);
		}
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
	}

	public void updatePlot(List<SpectralFluxInfo> pointInfo, int curIndex = -1) {
		if (plotPoints.Count < displayWindowSize - 1)
			return;

		int numPlotted = 0;
		int windowStart = 0;
		int windowEnd = 0;

		if (curIndex > 0) {
			windowStart = Mathf.Max (0, curIndex - displayWindowSize / 2);
			windowEnd = Mathf.Min (curIndex + displayWindowSize / 2, pointInfo.Count - 1);
		} else {
			windowStart = Mathf.Max (0, pointInfo.Count - displayWindowSize - 1);
			windowEnd = Mathf.Min (windowStart + displayWindowSize, pointInfo.Count);
		}
		
		float currentFlux;
		noteOneFlux = 0.05f;
		noteTwoFlux = 0.1f;

		/*float largestFlux = 0;

		for(int i = 0; i < pointInfo.Count; i++)
		{
			if(pointInfo[i].spectralFlux > largestFlux)
			{
				largestFlux = pointInfo[i].spectralFlux;
			}

		}

		float fluxDiv = largestFlux / 5;

		nothingFlux = fluxDiv;
		obstacleFlux = fluxDiv * 2;
		noteOneFlux = fluxDiv * 3;
		noteTwoFlux = fluxDiv * 4;


		Debug.Log(largestFlux); */

		for (int i = windowStart; i < windowEnd; i++) {
			int plotIndex = numPlotted;
			numPlotted++;

			



			/*if (pointInfo[i].spectralFlux > largestFlux)
			{
				largestFlux = pointInfo[i].spectralFlux;

				float fluxDiv = largestFlux / 5;

				nothingFlux = fluxDiv;
				obstacleFlux = fluxDiv * 2;
				noteOneFlux = fluxDiv * 3;
				noteTwoFlux = fluxDiv * 4;

			} */



			if ((int)(elapsedTime * 100) % ((int)(100 * secondsPerBeat / 4)) == 0 && elapsedTime != previousTime && (elapsedTime - previousTime > secondsPerBeat / 8)) 
			{
				previousTime = elapsedTime;
				spawnNote(pointInfo[i].spectralFlux);
			}
		}
	}



	public IEnumerator WaitForBeat()
	{
		yield return new WaitForSeconds(secondsPerBeat);
	}

	public void spawnNote(float currentFlux)
	{
		if (currentFlux <= noteOneFlux)
		{
			setNotePosition(noteOne, 0, -0.01f);
		}
		else if (currentFlux > noteOneFlux && currentFlux < noteTwoFlux)
		{
			setNotePosition(noteTwo, 2, 0.01f);
		}
		else if (currentFlux > noteTwoFlux)
		{
			setNotePosition(noteThree, -2, 0f);
		}


		StartCoroutine(WaitForBeat());

	}

	public void setNotePosition(GameObject note, float pointX, float pointZ)
	{
		float displayMultiplier = 2f;

		Vector3 SpawnPosition = new Vector3(pointX, pointZ);
		Instantiate(note, SpawnPosition, Quaternion.identity);
	}

}
