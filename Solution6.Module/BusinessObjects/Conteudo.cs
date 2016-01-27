using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Solution6.Module.BusinessObjects
{
    [NavigationItem]
    public class Conteudo : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Conteudo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string nome;
        string content;
        private Topico topico;

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
        [Size(SizeAttribute.Unlimited)]
        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                SetPropertyValue("Conteudo", ref content, value);
            }
        }

        [Association("Topico-Conteudos")]
        public Topico Topico
        {
            get
            {
                return topico;
            }

            set
            {
                SetPropertyValue("Topico", ref topico, value);
            }
        }
    }
}
