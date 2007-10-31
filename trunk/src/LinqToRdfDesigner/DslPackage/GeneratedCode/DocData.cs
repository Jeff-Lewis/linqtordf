﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;


namespace LinqToRdf.Design.DslPackage
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class LinqToRdfDesignerDocData : LinqToRdfDesignerDocDataBase
	{
		/// <summary>
		/// Constructs a new LinqToRdfDesignerDocData.
		/// </summary>
		public LinqToRdfDesignerDocData(global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId) 
			: base(serviceProvider, editorFactoryId)
		{
		}
	}

	/// <summary>
	/// Class which represents a LinqToRdfDesigner document in memory.
	/// </summary>
	internal abstract class LinqToRdfDesignerDocDataBase : DslShell::ModelingDocData
	{
		/// <summary>
		/// Document lock holder registered for the subordinate .diagram file.
		/// </summary>
		private DslShell::SubordinateDocumentLockHolder diagramDocumentLockHolder;

		/// <summary>
		/// Constructs a new LinqToRdfDesignerDocDataBase.
		/// </summary>
		protected LinqToRdfDesignerDocDataBase(global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId) : base(serviceProvider, editorFactoryId)
		{
		}

		/// <summary>
		/// Returns a list of file format specifiers for the Save dialog box.
		/// </summary>
		protected override string FormatList
		{
			get
			{
                return global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.SingletonResourceManager.GetString("FormatList"); 
			}
		}


		
		/// <summary>
		/// When the doc data is closed, make sure we reset the valiation messages 
		/// (if there's any) from the ErrorList window.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (this.diagramDocumentLockHolder != null)
				{
					this.diagramDocumentLockHolder.Dispose();
					this.diagramDocumentLockHolder = null;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		/// <summary>
		/// Returns a collection of domain models to load into the store.
		/// </summary>
		protected override global::System.Collections.Generic.IList<global::System.Type> GetDomainModels()
		{
			return new global::System.Type[]
			{
				typeof(DslDiagrams::CoreDesignSurfaceDomainModel),
				typeof(global::LinqToRdf.Design.LinqToRdfDesignerDomainModel)
			};
		}

		/// <summary>
		/// Loads the given file.
		/// </summary>
		protected override void Load(string fileName, bool isReload)
		{
			DslModeling::SerializationResult serializationResult = new DslModeling::SerializationResult();
			global::LinqToRdf.Design.ModelRoot modelRoot = null;
			DslModeling::ISchemaResolver schemaResolver = new DslShell::ModelingSchemaResolver(this.ServiceProvider);
			
			// Enable diagram fixup rules in our store, because we will load diagram data.
			global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.EnableDiagramRules(this.Store);
			string diagramFileName = fileName + this.DiagramExtension;
			
			modelRoot = global::LinqToRdf.Design.LinqToRdfDesignerSerializationHelper.Instance.LoadModelAndDiagram(serializationResult, this.Store, fileName, diagramFileName, schemaResolver, null /* no load-time validation */);

			// Report serialization messages.
			this.SuspendErrorListRefresh();
			try
			{
				foreach (DslModeling::SerializationMessage serializationMessage in serializationResult)
				{
					this.AddErrorListItem(new DslShell::SerializationErrorListItem(this.ServiceProvider, serializationMessage));
				}
			}
			finally
			{
				this.ResumeErrorListRefresh();
			}

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
				throw new global::System.InvalidOperationException(global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"));
			}
			else
			{
				this.SetRootElement(modelRoot);
				if (this.Hierarchy != null && global::System.IO.File.Exists(diagramFileName))
				{
					// Add a lock to the subordinate diagram file.
					if (this.diagramDocumentLockHolder == null)
					{
						uint itemId = DslShell::SubordinateFileHelper.GetChildProjectItemId(this.Hierarchy, this.ItemId, this.DiagramExtension);
						if (itemId != global::Microsoft.VisualStudio.VSConstants.VSITEMID_NIL)
						{
							this.diagramDocumentLockHolder = DslShell::SubordinateFileHelper.LockSubordinateDocument(this.ServiceProvider, this, diagramFileName, itemId);
							if (this.diagramDocumentLockHolder == null)
							{
								throw new global::System.InvalidOperationException(string.Format(System.Globalization.CultureInfo.CurrentCulture,
													global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.SingletonResourceManager.GetString("CannotCloseExistingDiagramDocument"),
													diagramFileName));
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Called after the document is opened.
		/// </summary>
		/// <param name="e">Event Args.</param>
		protected override void OnDocumentLoaded(global::System.EventArgs e)
		{
			base.OnDocumentLoaded(e);
			this.OnDocumentLoaded();
		}

		/// <summary>
		/// Called after the document is reloaded.
		/// </summary>
		protected override void OnDocumentReloaded(global::System.EventArgs e)
		{
			base.OnDocumentReloaded(e);
			this.OnDocumentLoaded();
		}
		
		/// <summary>
		/// Called on both document load and reload.
		/// </summary>
		protected virtual void OnDocumentLoaded()
		{

			// Enable CompartmentItems events.
			global::LinqToRdf.Design.ModelRoot modelRoot = this.RootElement as global::LinqToRdf.Design.ModelRoot;
			if (modelRoot != null)
			{
				global::System.Collections.Generic.IList<DslDiagrams::PresentationElement> diagrams = DslDiagrams::PresentationViewsSubject.GetPresentation(modelRoot);
				if (diagrams.Count > 0)
				{
					global::LinqToRdf.Design.ClassDiagram diagram = diagrams[0] as global::LinqToRdf.Design.ClassDiagram;
					if (diagram != null)
					{
						diagram.SubscribeCompartmentItemsEvents();
					}
				}
			}
		}


			
		/// <summary>
		/// Handle when document has been saved
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDocumentSaved(System.EventArgs e)
		{
			base.OnDocumentSaved(e);

			// Notify the Running Document Table that the subordinate has been saved
			// If this was a SaveAs, then let the subordinate document do this notification itself.
			// Otherwise VS will never ask the subordinate to save itself.
			DslShell::DocumentSavedEventArgs savedEventArgs = e as DslShell::DocumentSavedEventArgs;
			if (savedEventArgs != null && this.ServiceProvider != null)
			{
				if ( global::System.StringComparer.OrdinalIgnoreCase.Compare(savedEventArgs.OldFileName, savedEventArgs.NewFileName) == 0)
				{
					VSShellInterop::IVsRunningDocumentTable rdt = (VSShellInterop.IVsRunningDocumentTable)this.ServiceProvider.GetService(typeof(VSShellInterop::IVsRunningDocumentTable));
					if (rdt != null && this.diagramDocumentLockHolder != null && this.diagramDocumentLockHolder.SubordinateDocData != null)
					{
						global::Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(rdt.NotifyOnAfterSave(this.diagramDocumentLockHolder.SubordinateDocData.Cookie));
					}
				}
			}
		}

		/// <summary>
		/// Saves the given file.
		/// </summary>
		protected override void Save(string fileName)
		{
			DslModeling::SerializationResult serializationResult = new DslModeling::SerializationResult();
			global::LinqToRdf.Design.ModelRoot modelRoot = (global::LinqToRdf.Design.ModelRoot)this.RootElement;

			
			// Only save the diagrams if
			// a) There are any to save
			// b) This is NOT a SaveAs operation.  SaveAs should allow the subordinate document to control the save of its data as it is writing a new file.
			//    Except DO save the diagram on SaveAs if there isn't currently a diagram as there won't be a subordinate document yet to save it.

			bool saveAs = global::System.StringComparer.OrdinalIgnoreCase.Compare(fileName, this.FileName) != 0;

			global::System.Collections.Generic.IList<DslDiagrams::PresentationElement> diagrams = DslDiagrams::PresentationViewsSubject.GetPresentation(this.RootElement);
			if (diagrams.Count > 0 && (!saveAs || this.diagramDocumentLockHolder == null))
			{
				global::LinqToRdf.Design.ClassDiagram diagram = diagrams[0] as global::LinqToRdf.Design.ClassDiagram;
				if (diagram != null)
				{
					string diagramFileName = fileName + this.DiagramExtension;
					try
					{
						this.SuspendFileChangeNotification(diagramFileName);
						
						global::LinqToRdf.Design.LinqToRdfDesignerSerializationHelper.Instance.SaveModelAndDiagram(serializationResult, modelRoot, fileName, diagram, diagramFileName, this.Encoding, false);
					}
					finally
					{
						this.ResumeFileChangeNotification(diagramFileName);
					}
				}
			}
			else
			{
				global::LinqToRdf.Design.LinqToRdfDesignerSerializationHelper.Instance.SaveModel(serializationResult, modelRoot, fileName, this.Encoding, false);
			}
			// Report serialization messages.
			this.SuspendErrorListRefresh();
			try
			{
				foreach (DslModeling::SerializationMessage serializationMessage in serializationResult)
				{
					this.AddErrorListItem(new DslShell::SerializationErrorListItem(this.ServiceProvider, serializationMessage));
				}
			}
			finally
			{
				this.ResumeErrorListRefresh();
			}

			if (serializationResult.Failed)
			{	// Save failed.
				throw new global::System.InvalidOperationException(global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"));
			}
		}
		/// <summary>
		/// Mark that the document has changed and thus a new backup should be created
		/// </summary>
		/// <remarks>
		/// Call this method when you change the document's content
		/// </remarks>
		public override void MarkDocumentChangedForBackup()
		{
			base.MarkDocumentChangedForBackup();

			// Also mark the subordinate document as changed
			if (this.diagramDocumentLockHolder != null &&
				this.diagramDocumentLockHolder.SubordinateDocData != null)
			{
				this.diagramDocumentLockHolder.SubordinateDocData.MarkDocumentChangedForBackup();
			}
		}
		
		#region Diagram file management
		
		/// <summary>
		/// Save the given document that is subordinate to this document.
		/// </summary>
		/// <param name="subordinateDocument"></param>
		/// <param name="fileName"></param>
		protected override void SaveSubordinateFile(DslShell::DocData subordinateDocument, string fileName)
		{
			// In this case, the only subordinate is the diagram.
			DslModeling::SerializationResult serializationResult = new DslModeling::SerializationResult();

			global::System.Collections.Generic.IList<DslDiagrams::PresentationElement> diagrams = DslDiagrams::PresentationViewsSubject.GetPresentation(this.RootElement);
			if (diagrams.Count > 0)
			{
				global::LinqToRdf.Design.ClassDiagram diagram = diagrams[0] as global::LinqToRdf.Design.ClassDiagram;
				if (diagram != null)
				{
					try
					{
						this.SuspendFileChangeNotification(fileName);
						
						global::LinqToRdf.Design.LinqToRdfDesignerSerializationHelper.Instance.SaveDiagram(serializationResult, diagram, fileName, this.Encoding, false);
					}
					finally
					{
						this.ResumeFileChangeNotification(fileName);
					}
				}
			}
			// Report serialization messages.
			this.SuspendErrorListRefresh();
			try
			{
				foreach (DslModeling::SerializationMessage serializationMessage in serializationResult)
				{
					this.AddErrorListItem(new DslShell::SerializationErrorListItem(this.ServiceProvider, serializationMessage));
				}
			}
			finally
			{
				this.ResumeErrorListRefresh();
			}
			
			if (!serializationResult.Failed)
			{
				// Notify the Running Document Table that the subordinate has been saved
				if (this.ServiceProvider != null)
				{
					VSShellInterop::IVsRunningDocumentTable rdt = (VSShellInterop.IVsRunningDocumentTable)this.ServiceProvider.GetService(typeof(VSShellInterop::IVsRunningDocumentTable));
					if (rdt != null && this.diagramDocumentLockHolder != null && this.diagramDocumentLockHolder.SubordinateDocData != null)
					{
						global::Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(rdt.NotifyOnAfterSave(this.diagramDocumentLockHolder.SubordinateDocData.Cookie));
					}
				}
			}
			else
			{	
				// Save failed.
				throw new global::System.InvalidOperationException(global::LinqToRdf.Design.LinqToRdfDesignerDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"));
			}						
		}
		
		/// <summary>
		/// Provide a suffix for the diagram file
		/// </summary>
		protected virtual string DiagramExtension
		{
			get
			{
				return Constants.DefaultDiagramExtension;
			}
		}
		#endregion
		
		#region Base virtual overrides
		
		/// <summary>
		/// Return the model in XML format
		/// </summary>
		protected override string SerializedModel
		{
			get
			{
				global::LinqToRdf.Design.ModelRoot modelRoot = this.RootElement as global::LinqToRdf.Design.ModelRoot;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::LinqToRdf.Design.LinqToRdfDesignerSerializationHelper.Instance.GetSerializedModelString(modelRoot, this.Encoding);
				}
				return modelFile;
			}
		}
		#endregion
	}
}
