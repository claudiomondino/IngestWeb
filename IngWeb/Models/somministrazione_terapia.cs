//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class somministrazione_terapia
    {
        public int id { get; set; }
        public Nullable<int> ospite { get; set; }
        public Nullable<System.DateTime> data_somministrazione { get; set; }
        public string farmaco { get; set; }
        public string posologia { get; set; }
        public string via_somministrazione { get; set; }
        public string stato_somministrazione { get; set; }
        public string fascia_oraria { get; set; }
        public string nota_operatore { get; set; }
        public Nullable<int> operatore { get; set; }
        public Nullable<System.DateTime> data_ora { get; set; }
    }
}
