using UnityEngine;

namespace Horang.UINavigator
{
	public abstract class ViewBase : MonoBehaviour
	{
		public enum VisibleStates
		{
			Appearing,
			Appeared,
			Disappearing,
			Disappeared,
		}

		public abstract void ShowInitialize();
		public abstract void Show();
		public abstract void HideInitialize();
		public abstract void Hide();
	}
}