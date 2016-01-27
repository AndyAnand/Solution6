using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace Solution6.Module.BusinessObjects
{
    [NavigationItem]
    
    public abstract class Category : BaseObject, ITreeNode
    {
        private string nome;
        protected abstract ITreeNode Parent
        {
            get;
        }
        protected abstract IBindingList Children
        {
            get;
        }
        public Category(Session session) : base(session) { }
        [Size(40)]
        [RuleRequiredField("RuleRequiredField for Category.Nome",
            DefaultContexts.Save, messageTemplate:"O campo 'Nome' não pode ser vazio!")]
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                SetPropertyValue("Nome", ref nome, value);
            }
        }
        #region ITreeNode
        IBindingList ITreeNode.Children
        {
            get
            {
                return Children;
            }
        }
        string ITreeNode.Name
        {
            get
            {
                return Nome;
            }
        }
        ITreeNode ITreeNode.Parent
        {
            get
            {
                return Parent;
            }
        }
        #endregion
    }
}