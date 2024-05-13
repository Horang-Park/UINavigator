using Horang.UINavigator.UIView;

namespace Test
{
	public class FirstUIEventBinder : UIViewEventBinder
	{
		private readonly First _thisView;
		
		public FirstUIEventBinder(UIViewNavigator uiViewNavigatorInstance) : base(uiViewNavigatorInstance)
		{
			_thisView = UIViewNavigatorInstance.Get<First>("1");
		}
		
		public override void BindEvent()
		{
			_thisView.ButtonEvent = () =>
			{
				var second = UIViewNavigatorInstance.Get<Second>("2");

				UIViewNavigatorInstance.Push(second);
			};
		}
	}
}