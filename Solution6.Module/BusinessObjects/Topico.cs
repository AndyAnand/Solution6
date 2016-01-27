using System;

using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using DevExpress.Xpo.Metadata;
using System.Drawing;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Solution6.Module.BusinessObjects
{
    [Appearance("TaskNameBackColor", AppearanceItemType = "ViewItem", BackColor = "Aqua",
        TargetItems = "Icone", Context = "DetailView")]
    [RuleCriteria("RestricaoNome", DefaultContexts.Save, "Len(Nome) <= 40",
        "O campo 'Nome' não deve ter mais que 40 caracteres!",
        SkipNullOrEmptyValues = true)]
    [RuleCriteria("RestricaoDescricao", DefaultContexts.Save, "Len(Descricao) <= 500",
        "O campo 'Descrição' não deve ter mais que 500 caracteres!",
        SkipNullOrEmptyValues = true)]
    public class Topico : Category
    {
        private string descricao;
        private Topico topico;
        
        protected override ITreeNode Parent
        {
            get
            {
                return topico;
            }
        }

        protected override IBindingList Children
        {
            get
            {
                return Topicos;
            }
        }

        public Topico(Session session) : base(session) { }
        public Topico(Session session, string nome)
            : base(session)
        {
            this.Nome = nome;
        }

        [Size(500)]
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                SetPropertyValue("Descricao", ref descricao, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        [ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit,
        DetailViewImageEditorFixedWidth = 70, DetailViewImageEditorFixedHeight = 70)]
        public Image Icone
        {
            get { return GetPropertyValue<Image>("Icone"); }
            set
            {
                SetPropertyValue<Image>("Icone", value);
            }
        }

        [Association("TopicoTopico")]
        public Topico TopicoPai
        {
            get
            {
                return topico;
            }
            set
            {
                SetPropertyValue("TopicoPai", ref topico, value);
            }
        }

        [Association("TopicoTopico"), Aggregated]
        public XPCollection<Topico> Topicos
        {
            get
            {
                return GetCollection<Topico>("Topicos");
            }
        }
        
        [Association("Topico-Conteudos")]
        public XPCollection<Conteudo> Conteudos
        {
            get
            {
                return GetCollection<Conteudo>("Conteudos");
            }
        }
        
        [NonPersistent]
        [Browsable(false)]
        public bool IsNew
        {
            get
            {
                return Session.IsNewObject(this);
            }
        }        
    }
}