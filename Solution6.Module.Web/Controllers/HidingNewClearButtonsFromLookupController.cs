using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;
using Solution6.Module.BusinessObjects;
using System.Web.UI.WebControls;

namespace Solution6.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class HidingNewClearButtonsFromLookupController : ViewController
    {
        public HidingNewClearButtonsFromLookupController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            this.ViewControlsCreated += TopicoLookupEditorHideNew_ViewControlsCreated;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            this.ViewControlsCreated -= TopicoLookupEditorHideNew_ViewControlsCreated;
            base.OnDeactivated();
        }

        private void TopicoLookupEditorHideNew_ViewControlsCreated(object sender, EventArgs e)
        {
            DetailView detailView = View as DetailView;

            if (detailView != null && View.CurrentObject is Conteudo && detailView.ViewEditMode == ViewEditMode.Edit)
            {
                ASPxLookupPropertyEditor editor = null;

                foreach (ViewItem i in (View as DetailView).Items)
                {
                    if (i is ASPxLookupPropertyEditor)
                        editor = i as ASPxLookupPropertyEditor;
                }
                if (editor != null)
                {
                    editor.Frame.GetController<NewObjectViewController>().NewObjectAction.Active.SetItemValue("LookupEditorMode", false);
                }
            }
        }
    }
}
