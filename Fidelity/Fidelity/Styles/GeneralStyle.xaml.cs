using Xamarin.Forms;

namespace Fidelity
{
    public partial class GeneralStyle : ResourceDictionary
	{
		public static GeneralStyle SharedInstance { get; } = new GeneralStyle();
		public GeneralStyle ()
		{
			InitializeComponent ();
		}
	}
}