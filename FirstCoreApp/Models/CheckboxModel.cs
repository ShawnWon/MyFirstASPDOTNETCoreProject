using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Models
{
    public class CheckboxModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsChecked { get; set; }

        public CheckboxModel(string text, bool ischecked)
        {
            
            this.Text = text;
            this.IsChecked = ischecked;
        
        }

        public CheckboxModel()
        { }

    }

    
}
