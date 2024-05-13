using System;
using UnityEngine;

namespace Horang.UINavigator.UIView
{
	public abstract class UIView : ViewBase
	{
		public VisibleStates VisibleState
		{
			get => _visibleStates;
			set => SetState(value);
		}
		private VisibleStates _visibleStates;
		
		private CanvasGroup _canvasGroup;
		
		public virtual void InitializeOnce()
		{
			_canvasGroup = gameObject.AddComponent<CanvasGroup>();
			_canvasGroup.hideFlags = HideFlags.HideInInspector;
			
			VisibleState = VisibleStates.Disappeared;
		}

		private void SetState(VisibleStates value)
		{
			_visibleStates = value;
			
			switch (value)
			{
				case VisibleStates.Appearing:
					gameObject.SetActive(true);
					_canvasGroup.interactable = false;
					break;
				case VisibleStates.Appeared:
					_canvasGroup.interactable = true;
					break;
				case VisibleStates.Disappearing:
					_canvasGroup.interactable = false;
					break;
				case VisibleStates.Disappeared:
					gameObject.SetActive(false);
					_canvasGroup.interactable = false;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(value), value, null);
			}
		}
	}
}