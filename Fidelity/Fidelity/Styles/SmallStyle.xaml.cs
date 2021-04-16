using Xamarin.Forms;

namespace Fidelity
{
    public partial class SmallStyle : ResourceDictionary
	{
		public static SmallStyle SharedInstance { get; } = new SmallStyle();
		public SmallStyle ()
		{
			InitializeComponent ();
		}
	}
}