using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Diagnostics;
using Solution6.Module.BusinessObjects;

namespace Solution6.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TopicoListViewController : ViewController
    {
        private AppearanceController appearanceController;
        public TopicoListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            appearanceController = Frame.GetController<AppearanceController>();
            if (appearanceController != null)
            {
                appearanceController.CustomApplyAppearance += appearanceController_CustomApplyAppearance;
            }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            if (appearanceController != null)
            {
                appearanceController.CustomApplyAppearance -= appearanceController_CustomApplyAppearance;
            }
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        void appearanceController_CustomApplyAppearance(object sender, ApplyAppearanceEventArgs e)
        {
            Topico topico = null;

            topico = View.CurrentObject as Topico;
            // Customizacoes de visibilidade de atributos na detailview dependendo da hierarquia de topicos

            if (e.Item is ColumnWrapper)
            {
                switch (e.ItemName)
                {
                    case "Icone":
                        e.AppearanceObject.Visibility = ViewItemVisibility.Show;
                        break;
                    case "Descricao":
                        e.AppearanceObject.Visibility = ViewItemVisibility.Show;
                        break;
                    case "Nome":
                        e.AppearanceObject.Visibility = ViewItemVisibility.Show;
                        break;
                }
            }
        }

        private void TopicoListViewController_Activated(object sender, EventArgs e)
        {
            /*
            Topico topico = null;
            
            if (!View.IsRoot)
            {
                if ((View as ListView).CollectionSource is PropertyCollectionSource)
                {
                    PropertyCollectionSource collectionSource =
                        (PropertyCollectionSource)(View as ListView).CollectionSource;
                    topico = collectionSource.MasterObject as Topico;
                }
                Debug.WriteLine("Eu tenho conteudo? " + topico.Conteudo.Content);
                if (topico.Conteudo != null)
                    Frame.GetController<NewObjectViewController>().NewObjectAction.Active.SetItemValue("Número máximo de niveis excedidos", false);
            }
            */
        }
    }
}
