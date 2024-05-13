namespace Horang.UINavigator.UIView
{
	public abstract class UIViewEventBinder
	{
		protected readonly UIViewNavigator UIViewNavigatorInstance;

		public abstract void BindEvent();

		protected UIViewEventBinder(UIViewNavigator uiViewNavigatorInstance)
		{
			UIViewNavigatorInstance = uiViewNavigatorInstance;
		}
	}
}