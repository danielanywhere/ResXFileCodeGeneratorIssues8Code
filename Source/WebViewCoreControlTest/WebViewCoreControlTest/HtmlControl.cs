//	HtmlControl.cs
//	Copyright(c) 2022. Ascendant Design and Training, LLC
//	This file is licensed under the MIT License.
//	Please see the LICENSE file in this project.
//
//	*** WARNING ***
//	This file is for diagnostic purposes only and has been configured to
//	cause a specific error. Much of its normal functionality is missing and
//	it is not suitable for production.
//	***
using System.Diagnostics;

namespace WebViewCoreControlTest
{
	//*-------------------------------------------------------------------------*
	//*	HtmlControl																															*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Pre-initialized HTML5 control.
	/// </summary>
	public partial class HtmlControl : UserControl
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		private List<string> mCommands = new List<string>();
		private bool mContextLoaded = false;

		//*-----------------------------------------------------------------------*
		//* InitializeAsync																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Initialize the webview control, and wait for it to be ready.
		/// </summary>
		/// <remarks>
		/// After initialization, all queued JavaScript commands will be run
		/// before marking the control as ready.
		/// </remarks>
		private async Task InitializeAsync()
		{
			string html = "";

			await webView.EnsureCoreWebView2Async(null);
			if(!DesignMode)
			{
				try
				{
					html = ResourceMain.htmlDefault;
				}
				catch(Exception ex)
				{
					Debug.WriteLine($"Error... {ex.Message}");
					html = @"<!doctype html>
<html>
<head>
<title>Error Message</title>
</head>
<body>
<p>Error loading HTML from resource. Please see debug/trace stream for more information.</p>
<p>ResourceMain will work from here if 
ResourceMain.Designer.cs.ResourceManager uses namespace prefixes on line 42.</p>
</body>
</html>";
				}
				webView.NavigateToString(html);
			}
			mContextLoaded = true;
		}
		//*-----------------------------------------------------------------------*

		////*-----------------------------------------------------------------------*
		////*	mEmbeddedBuffer_ValueChanged																					*
		////*-----------------------------------------------------------------------*
		///// <summary>
		///// Called when the value of the embedded buffer has changed.
		///// </summary>
		///// <param name="sender">
		///// The object raising this event.
		///// </param>
		///// <param name="e">
		///// Standard event arguments.
		///// </param>
		//private void mEmbeddedBuffer_ValueChanged(object sender, EventArgs e)
		//{
		//	Debug.WriteLine("Embedded buffer value has changed...");
		//}
		////*-----------------------------------------------------------------------*

		////*-----------------------------------------------------------------------*
		////* timer_Tick																														*
		////*-----------------------------------------------------------------------*
		///// <summary>
		///// The timer has elapsed.
		///// </summary>
		///// <param name="sender">
		///// The object raising this event.
		///// </param>
		///// <param name="e">
		///// Standard event arguments.
		///// </param>
		//private void timer_Tick(object sender, EventArgs e)
		//{
		//	if(mInitializing)
		//	{
		//		timer.Stop();
		//		mInitializing = false;
		//	}
		//}
		////*-----------------------------------------------------------------------*

		////*-----------------------------------------------------------------------*
		////* webView_NavigationCompleted																						*
		////*-----------------------------------------------------------------------*
		///// <summary>
		///// Navigation has completed and the page is ready to display.
		///// </summary>
		///// <param name="sender">
		///// The object raising this event.
		///// </param>
		///// <param name="e">
		///// Core webview2 navigation completed event arguments.
		///// </param>
		//private void webView_NavigationCompleted(object sender,
		//	CoreWebView2NavigationCompletedEventArgs e)
		//{
		//	mAwaitingNavigationCompleted = false;
		//}
		////*-----------------------------------------------------------------------*

		////*-----------------------------------------------------------------------*
		////* webView_WebMessageReceived																						*
		////*-----------------------------------------------------------------------*
		///// <summary>
		///// Raises the MessageReceived event when a message has been received from
		///// the browser control.
		///// </summary>
		///// <param name="sender">
		///// Object raising this event.
		///// </param>
		///// <param name="e">
		///// Core webview2 web message received event arguments.
		///// </param>
		//private void webView_WebMessageReceived(object sender,
		//	CoreWebView2WebMessageReceivedEventArgs e)
		//{
		//	string message = "";
		//	try
		//	{
		//		message = e.TryGetWebMessageAsString();
		//	}
		//	catch(Exception ex)
		//	{
		//		Debug.WriteLine($"Error on HTMLControl: {ex.Message}");
		//	}
		//	if(message == null)
		//	{
		//		message = "";
		//	}
		//	Debug.WriteLine($"HtmlControl: {message}");
		//	mMessages.Add(message);
		//	mAwaitingWebMessageReceived = false;
		//}
		////*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//* Dispose																																*
		//*-----------------------------------------------------------------------*
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">
		/// True if managed resources should be disposed; otherwise, false.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if(webView != null)
			{
				webView.Stop();
				webView.Visible = false;
				webView.Dispose();
				webView = null;
			}
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		//*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//* _Constructor                                                          *
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Create a new instance of the HTMLControl.
		/// </summary>
		public HtmlControl()
		{
			InitializeComponent();
			if(!DesignMode)
			{
				_ = InitializeAsync();
				//webView.NavigationCompleted += webView_NavigationCompleted;
			}
			this.timer.Interval = 500;
			//this.timer.Tick += timer_Tick;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	AwaitingNavigationCompleted																						*
		//*-----------------------------------------------------------------------*
		private bool mAwaitingNavigationCompleted = false;
		/// <summary>
		/// Get/Set a value indicating whether the control is currently awaiting
		/// the NavigationCompleted event.
		/// </summary>
		public bool AwaitingNavigationCompleted
		{
			get { return mAwaitingNavigationCompleted; }
			set { mAwaitingNavigationCompleted = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	AwaitingWebMessageReceived																						*
		//*-----------------------------------------------------------------------*
		private bool mAwaitingWebMessageReceived = false;
		/// <summary>
		/// Get/Set a value indicating whether the host is waiting for a web
		/// message to be received.
		/// </summary>
		public bool AwaitingWebMessageReceived
		{
			get { return mAwaitingWebMessageReceived; }
			set { mAwaitingWebMessageReceived = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* JavaScriptCommand																											*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Execute a JavaScript command on the client.
		/// </summary>
		/// <param name="value">
		/// JavaScript command to execute.
		/// </param>
		public void JavaScriptCommand(string value)
		{
			if(mContextLoaded)
			{
				webView.ExecuteScriptAsync(value);
			}
			else
			{
				mCommands.Add(value);
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Messages																															*
		//*-----------------------------------------------------------------------*
		private List<string> mMessages = new List<string>();
		/// <summary>
		/// Get a reference to the collection of messages received from the client.
		/// </summary>
		public List<string> Messages
		{
			get { return mMessages; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* Navigate																															*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Navigate to the specified URL.
		/// </summary>
		/// <param name="url">
		/// URL to navigate to.
		/// </param>
		/// <returns>
		/// True if the the page navigation was complete before returning.
		/// Otherwise, false.
		/// </returns>
		public async Task Navigate(string url)
		{
			int index = 0;
			int maxCount = 10;

			mAwaitingNavigationCompleted = true;
			webView.CoreWebView2.Navigate(url);
			while(index < maxCount && mAwaitingNavigationCompleted)
			{
				await Task.Delay(1000);
				index++;
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* NavigateAsync																													*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Navigate to the specified URL.
		/// </summary>
		/// <param name="url">
		/// URL to navigate to.
		/// </param>
		/// <returns>
		/// True if the the page navigation was complete before returning.
		/// Otherwise, false.
		/// </returns>
		public void NavigateAsync(string url)
		{
			mAwaitingNavigationCompleted = true;
			webView.CoreWebView2.Navigate(url);
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	NavigateToString																											*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Supply the HTML content for the document and render it, waiting for
		/// the page load to be complete before returning.
		/// </summary>
		/// <param name="htmlContent">
		/// Content to load.
		/// </param>
		/// <returns>
		/// True if the the page navigation was complete before returning.
		/// Otherwise, false.
		/// </returns>
		public bool NavigateToString(string htmlContent)
		{
			int index = 0;
			int maxCount = 10;

			mAwaitingNavigationCompleted = true;
			webView.NavigateToString(htmlContent);
			while(index < maxCount && mAwaitingNavigationCompleted)
			{
				Thread.Sleep(500);
				index++;
			}
			return !mAwaitingNavigationCompleted;
		}
		//*-----------------------------------------------------------------------*

	}
	//*-------------------------------------------------------------------------*
}