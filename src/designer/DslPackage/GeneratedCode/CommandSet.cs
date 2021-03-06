﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using VSShell = global::Microsoft.VisualStudio.Shell;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;

namespace LinqToRdf.Design.DslPackage
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class LinqToRdfCommandSet : LinqToRdfCommandSetBase
	{
		/// <summary>
		/// Constructs a new LinqToRdfCommandSet.
		/// </summary>
		public LinqToRdfCommandSet(global::System.IServiceProvider serviceProvider) 
			: base(serviceProvider)
		{
		}
	}

	/// <summary>
	/// Class containing handlers for commands supported by this DSL.
	/// </summary>
	internal abstract class LinqToRdfCommandSetBase : DslShell::CommandSet
	{
		/// <summary>
		/// Constructs a new LinqToRdfCommandSetBase.
		/// </summary>
		protected LinqToRdfCommandSetBase(global::System.IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

		/// <summary>
		/// Provide the menu commands that this command set handles
		/// </summary>
		protected override global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> GetMenuCommands()
		{
			// Get the standard commands
			global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> commands = base.GetMenuCommands();

			global::System.ComponentModel.Design.MenuCommand menuCommand;
			// Add command handler for the "view explorer" command in the top-level menu.
			// We use a ContextBoundMenuCommand because the visibility of this command is
			// based on whether or not the command context of our DSL editor is active. 
			menuCommand = new DslShell::CommandContextBoundMenuCommand(this.ServiceProvider,
				new global::System.EventHandler(OnMenuViewModelExplorer),
				Constants.ViewLinqToRdfExplorerCommand,
				typeof(LinqToRdfEditorFactory).GUID);

			commands.Add(menuCommand);

			return commands;
		}
		/// <summary>
		/// Command handler that shows the explorer tool window.
		/// </summary>
		internal virtual void OnMenuViewModelExplorer(object sender, global::System.EventArgs e)
		{
			LinqToRdfExplorerToolWindow explorer = this.LinqToRdfExplorerToolWindow;
			if (explorer != null)
			{
				explorer.Show();
			}
		}


		/// <summary>
		/// Returns the currently focused document.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected LinqToRdfDocData CurrentLinqToRdfDocData
		{
			get
			{
				return this.MonitorSelection.CurrentDocument as LinqToRdfDocData;
			}
		}

		/// <summary>
		/// Returns the currently focused document view.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected LinqToRdfDocView CurrentLinqToRdfDocView
		{
			get
			{
				return this.MonitorSelection.CurrentDocumentView as LinqToRdfDocView;
			}
		}

		/// <summary>
		/// Returns the explorer tool window.
		/// </summary>
		protected LinqToRdfExplorerToolWindow LinqToRdfExplorerToolWindow
		{
			get
			{
				LinqToRdfExplorerToolWindow explorerWindow = null;
				DslShell::ModelingPackage package = this.ServiceProvider.GetService(typeof(VSShell::Package)) as DslShell::ModelingPackage;

				if (package != null)
				{
					explorerWindow = package.GetToolWindow(typeof(LinqToRdfExplorerToolWindow), true) as LinqToRdfExplorerToolWindow;
				}

				return explorerWindow;
			}
		}

		/// <summary>
		/// Returns the currently selected object in the model explorer.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected object ExplorerSelection
		{
			get
			{
				object selection = null;
				LinqToRdfExplorerToolWindow explorerWindow = this.LinqToRdfExplorerToolWindow;
				
				if(explorerWindow != null)
				{
					foreach (object o in explorerWindow.GetSelectedComponents())
					{
						selection = o;
						break;
					}
				}

				return selection;
			}
		}
	}
}

