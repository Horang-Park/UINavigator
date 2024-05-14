using Horang.UINavigator;
using Horang.UINavigator.UIView;

namespace Test.EventBinders
{
	public class FirstUIEventBinder : UIViewEventBinder
	{
		private First _thisView;

		public override void Bind(UIViewNavigator navigatorInstance)
		{
			_thisView = navigatorInstance.Get<First>("1");
			
			_thisView.ButtonEvent = () =>
			{
				var second = navigatorInstance.Get<Second>("2");

				navigatorInstance.Push(second);
			};
		}
	}
}