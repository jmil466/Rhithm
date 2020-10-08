using System.Collections;
using System.Collections.Generic;
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


	// Use this for initialization
	void Start () {
		plotPoints = new List<Transform> ();

		secondsPerBeat = 60 / BPM;

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


		



		for (int i = windowStart; i < windowEnd; i++) {
			int plotIndex = numPlotted;
			numPlotted++;

			/* Transform fluxPoint = plotPoints [plotIndex].Find ("FluxPoint");
			Transform threshPoint = plotPoints [plotIndex].Find ("ThreshPoint");
			Transform peakPoint = plotPoints [plotIndex].Find ("PeakPoint");*/


			if (elapsedTime % (secondsPerBeat / 4) <= 0.015)
			{
				

				if (pointInfo[i].spectralFlux <= 0.025)
				{
					//Produce Nothing!
					//Debug.Log("Flux " + pointInfo[i].spectralFlux);
				}
				else if (pointInfo[i].spectralFlux > 0.025 && pointInfo[i].spectralFlux <= 0.05)
				{
					//Produce Obstacle
					//Debug.Log("Flux " + pointInfo[i].spectralFlux);
				}
				else if (pointInfo[i].spectralFlux > 0.05 && pointInfo[i].spectralFlux <= 0.1)
				{
					//Produce Green
					Debug.Log("Flux " + pointInfo[i].spectralFlux);
					setNotePosition(noteTwo, 0.05f, 0.01f, 2f);
				}
				else if (pointInfo[i].spectralFlux > 0.1 && pointInfo[i].spectralFlux <= 0.15)
				{
					//Produce Blue
					Debug.Log("Flux " + pointInfo[i].spectralFlux);
					setNotePosition(noteOne, pointInfo[i].threshold, -0.01f, 0f);
				}
				else
				{
					// Produce Red Note
					Debug.Log("Flux " + pointInfo[i].spectralFlux);
					setNotePosition(noteThree, pointInfo[i].spectralFlux, 0f, -2f);
				}

				StartCoroutine(WaitForBeat());
			}



			/*

			if (pointInfo[i].isPeak)
				{
					setPointHeight(peakPoint, pointInfo[i].spectralFlux);
					setPointHeight(fluxPoint, 0f);

					Debug.Log("PointInfo" + pointInfo[i].spectralFlux);

				}
				else
				{
					setPointHeight(fluxPoint, pointInfo[i].spectralFlux);
					setPointHeight(peakPoint, 0f);
				}
				setPointHeight(threshPoint, pointInfo[i].threshold);
		
	*/

		}
	}

	public IEnumerator WaitForBeat()
	{
		yield return new WaitForSeconds(secondsPerBeat);
	}

	public void setPointHeight(Transform point, float height) {
		float displayMultiplier = 0.06f;

		point.localPosition = new Vector3(point.localPosition.x, height * displayMultiplier, point.localPosition.z);
	}

	public void setNotePosition(GameObject note, float height, float pointZ, float pointX)
	{
		float displayMultiplier = 2f;

		Vector3 SpawnPosition = new Vector3(pointX, height * displayMultiplier, pointZ);
		Instantiate(note, SpawnPosition, Quaternion.identity);

		//point.localPosition = new Vector3(point.localPosition.x, height * displayMultiplier, pointZ);

		//Debug.Log("Help " + point.localPosition.x);
	}

}
