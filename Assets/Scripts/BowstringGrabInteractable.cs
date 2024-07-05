using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BowstringGrabInteractable : XRGrabInteractable
{
	[SerializeField]
	private Transform[] stringHoldPoints;
	private LineRenderer lineRenderer;
	private IXRSelectInteractor interactor;
	private bool isGrabbed;

	protected override void Awake()
	{
		base.Awake();
		lineRenderer = GetComponentInChildren<LineRenderer>();
	}

	protected override void Grab()
	{
		base.Grab();
		isGrabbed = true;
	}

	protected override void Drop()
	{
		base.Drop();
		isGrabbed = false;	
	}

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args);
		this.interactor = args.interactorObject;
	}

	private void Update()
	{
		if(isGrabbed && interactor != null)
		{
			AdjustLineRenderer();
		}
	}

	private void AdjustLineRenderer()
	{
		var stringPositions = new Vector3[] { stringHoldPoints[0].position, interactor.transform.position, stringHoldPoints[1].position };
		lineRenderer.SetPositions(stringPositions);
	}
}
