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
    
    public partial class anagrafica_medici
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string cognome { get; set; }
        public string nome { get; set; }
        public Nullable<System.DateTime> data_nascita { get; set; }
        public string comune_nascita { get; set; }
        public string provincia_nascita { get; set; }
        public string cap_nascita { get; set; }
        public string codice_fiscale { get; set; }
        public string indirizzo_ufficio { get; set; }
        public string localita_ufficio { get; set; }
        public string provincia_ufficio { get; set; }
        public string cap_ufficicio { get; set; }
        public string telefono { get; set; }
        public string cellulare { get; set; }
        public string id_regionale { get; set; }
        public string indirizzo_mail { get; set; }
        public string attivo_sn { get; set; }
        public Nullable<int> user_id { get; set; }
        public string cpccchk { get; set; }
        public string enabled { get; set; }
    }
}
