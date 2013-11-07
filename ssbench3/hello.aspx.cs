
namespace ssbench3
{
	using System;
	using System.Web;
	using System.Web.UI;

	public partial class hello : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			Response.Write("<p>Hello, world!</p>");
		}
	}
}

