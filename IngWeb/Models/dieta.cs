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
    
    public partial class dieta
    {
        public decimal id { get; set; }
        public string oggetto { get; set; }
        public string descrizione { get; set; }
        public byte[] data_ora { get; set; }
        public string ospite { get; set; }
        public Nullable<int> id_user_inserimento { get; set; }
        public string firmato { get; set; }
        public string cpccchk { get; set; }
    }
}
