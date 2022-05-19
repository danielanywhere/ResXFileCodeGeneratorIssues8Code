namespace WebViewCoreControlTest
{
	partial class HtmlControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// webView
			// 
			this.webView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView.Location = new System.Drawing.Point(0, 0);
			this.webView.Name = "webView";
			this.webView.Size = new System.Drawing.Size(218, 150);
			this.webView.Source = new System.Uri("about:blank", System.UriKind.Absolute);
			this.webView.TabIndex = 0;
			this.webView.ZoomFactor = 1D;
			// 
			// HTMLControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.webView);
			this.Name = "HTMLControl";
			this.Size = new System.Drawing.Size(218, 150);
			this.ResumeLayout(false);
		}

		#endregion

		private Microsoft.Web.WebView2.WinForms.WebView2 webView;
		private System.Windows.Forms.Timer timer;
	}
}