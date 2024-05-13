using Horang.UINavigator.UIView;
using UnityEngine;

namespace Test
{
	public class TestRunner : MonoBehaviour
	{
		[SerializeField] private UIViewNavigator uiViewNavigator;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				var first = uiViewNavigator.Get<First>("1");
				
				uiViewNavigator.Push(first);
			}
			
			if (Input.GetKeyDown(KeyCode.F2))
			{
				var second = uiViewNavigator.Get<Second>("2");
				
				uiViewNavigator.Push(second);
			}
			
			if (Input.GetKeyDown(KeyCode.F3))
			{
				var third = uiViewNavigator.Get<Third>("3");
				
				uiViewNavigator.Push(third);
			}
			
			if (Input.GetKeyDown(KeyCode.F4))
			{
				uiViewNavigator.Pop();
			}

			if (Input.GetKeyDown(KeyCode.F5))
			{
				uiViewNavigator.PopLeastOne();
			}
		}
	}
}