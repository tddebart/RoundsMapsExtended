﻿using UnityEngine;

namespace MapsExt.Editor.ActionHandlers
{
	public class RopeActionHandler : EditorActionHandler
	{
		public override bool CanMove() => true;
		public override bool CanResize() => false;
		public override bool CanRotate() => false;

		public override bool Move(Vector3 positionDelta)
		{
			this.GetComponent<MapObjectAnchor>().Detach();
			this.transform.position += positionDelta;
			this.GetComponent<MapObjectAnchor>().UpdateAttachment();
			return true;
		}

		public override bool Resize(Vector3 sizeDelta, int resizeDirection)
		{
			return false;
		}

		public override bool SetRotation(Quaternion rotation)
		{
			return false;
		}
	}
}